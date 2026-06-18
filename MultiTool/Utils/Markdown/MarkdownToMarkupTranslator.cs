using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;
using Color = Spectre.Console.Color;
using Panel = Spectre.Console.Panel;

namespace MultiTool.Utils.Markdown;

public class MarkdownToMarkupTranslator {
    private List<string[]> tableRowsBuffer = new List<string[]>();

    public List<IRenderable> translateToRenderables(List<MarkdownToken> tokens) {
        List<IRenderable> renderables = new List<IRenderable>();
        StringBuilder inlineBuilder = new StringBuilder();

        for (int i = 0; i < tokens.Count; i++) {
            MarkdownToken token = tokens[i];

            if (token.getType() != MarkdownTokenType.TABLE_ROW) flushTableBuffer(renderables);

            if (token is MarkdownCodeToken codeToken) {
                flushInlineBuffer(inlineBuilder, renderables);
                processCodeToken(codeToken, renderables);
                continue;
            }

            if (token.getType() == MarkdownTokenType.TABLE_ROW) {
                flushInlineBuffer(inlineBuilder, renderables);
                processTableRowToken(token);
                continue;
            }

            processStandardInlineToken(token, inlineBuilder, renderables);
        }

        flushInlineBuffer(inlineBuilder, renderables);
        flushTableBuffer(renderables);
        return renderables;
    }

    private void processTableRowToken(MarkdownToken token) {
        string rawLine = token.getValue().Trim('|');
        if (rawLine.Replace(" ", "").Contains("---")) return;

        string[] cells = rawLine.Split('|');
        for (int i = 0; i < cells.Length; i++) cells[i] = cells[i].Trim();
        tableRowsBuffer.Add(cells);
    }

    private void flushTableBuffer(List<IRenderable> renderables) {
        if (tableRowsBuffer.Count == 0) return;

        Table table = new Table().Border(TableBorder.Rounded).BorderColor(Color.Teal);
        string[] headers = tableRowsBuffer[0];
        
        for (int i = 0; i < headers.Length; i++) table.AddColumn(new TableColumn($"[bold teal]{headers[i]}[/]"));

        for (int row = 1; row < tableRowsBuffer.Count; row++) {
            string[] rawRow = tableRowsBuffer[row];
            if (rawRow.Length < headers.Length) continue;
            
            string[] formattedRow = new string[headers.Length];
            for (int col = 0; col < headers.Length; col++) {
                List<MarkdownToken> inlineTokens = new MarkdownLexer().tokenize(rawRow[col]);
                StringBuilder cellBuilder = new StringBuilder();
                foreach (MarkdownToken token in inlineTokens) {
                    if (token.getType() == MarkdownTokenType.TEXT) cellBuilder.Append(escapeMarkup(token.getValue()));
                    else if (token.getType() == MarkdownTokenType.BOLD) cellBuilder.Append($"[bold]{escapeMarkup(token.getValue())}[/]");
                    else cellBuilder.Append(escapeMarkup(token.getValue()));
                }
                formattedRow[col] = cellBuilder.ToString();
            }
            table.AddRow(formattedRow);
        }

        renderables.Add(table);
        tableRowsBuffer.Clear();
    }

    private void processStandardInlineToken(MarkdownToken token, StringBuilder inlineBuilder, List<IRenderable> renderables) {
        switch (token.getType()) {
            case MarkdownTokenType.H1: inlineBuilder.Append($"[bold underline red]{escapeMarkup(token.getValue())}[/]\n"); break;
            case MarkdownTokenType.H2: inlineBuilder.Append($"[bold orange1]{escapeMarkup(token.getValue())}[/]\n"); break;
            case MarkdownTokenType.H3: inlineBuilder.Append($"[bold yellow]{escapeMarkup(token.getValue())}[/]\n"); break;
            case MarkdownTokenType.H4: inlineBuilder.Append($"[bold italic green]{escapeMarkup(token.getValue())}[/]\n"); break;
            case MarkdownTokenType.H5: inlineBuilder.Append($"[bold blue]{escapeMarkup(token.getValue())}[/]\n"); break;
            case MarkdownTokenType.H6: inlineBuilder.Append($"[italic purple]{escapeMarkup(token.getValue())}[/]\n"); break;
            case MarkdownTokenType.BOLD: inlineBuilder.Append($"[bold]{escapeMarkup(token.getValue())}[/]"); break;
            case MarkdownTokenType.ITALIC: inlineBuilder.Append($"[italic]{escapeMarkup(token.getValue())}[/]"); break;
            case MarkdownTokenType.STRIKETHROUGH: inlineBuilder.Append($"[strikethrough]{escapeMarkup(token.getValue())}[/]"); break;
            case MarkdownTokenType.HIGHLIGHT: inlineBuilder.Append($"[black on yellow]{escapeMarkup(token.getValue())}[/]"); break;
            case MarkdownTokenType.BLOCKQUOTE: inlineBuilder.Append("[silver]│[/] "); break;
            case MarkdownTokenType.HORIZONTAL_RULE: inlineBuilder.Append("[silver]────────────────────────────────────────[/]\n"); break;
            case MarkdownTokenType.CODE_IN_LINE: inlineBuilder.Append($"[black on white]{escapeMarkup(token.getValue())}[/]"); break;
            case MarkdownTokenType.ORDERED_LIST_ITEM: inlineBuilder.Append($"[yellow]{escapeMarkup(token.getValue())}[/]"); break;
            case MarkdownTokenType.UNORDERED_LIST_ITEM: inlineBuilder.Append($"[yellow]{escapeMarkup(token.getValue())}[/]"); break;
            case MarkdownTokenType.TASK_LIST_ITEM_CHECKED: inlineBuilder.Append("[green][[x]][/] "); break;
            case MarkdownTokenType.TASK_LIST_ITEM_UNCHECKED: inlineBuilder.Append("[red][[ ]][/] "); break;
            case MarkdownTokenType.TEXT: inlineBuilder.Append(escapeMarkup(token.getValue())); break;
            case MarkdownTokenType.NEW_LINE: inlineBuilder.Append('\n'); break;
        }
    }

    private void processCodeToken(MarkdownCodeToken token, List<IRenderable> renderables) {
        if (token.getType() == MarkdownTokenType.MULTILINE_CODE) {
            StringBuilder panelBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(token.getLanguage())) panelBuilder.Append($"[italic yellow]{token.getLanguage().ToUpper()}:[/]\n");
            panelBuilder.Append($"[blue]{escapeMarkup(token.getValue())}[/]");

            Panel panel = new Panel(panelBuilder.ToString()).Border(BoxBorder.Rounded).BorderColor(Color.Grey);
            renderables.Add(panel);
        }
    }

    private void flushInlineBuffer(StringBuilder inlineBuilder, List<IRenderable> renderables) {
        if (inlineBuilder.Length > 0) {
            renderables.Add(new Markup(inlineBuilder.ToString()));
            inlineBuilder.Clear();
        }
    }

    private string escapeMarkup(string text) => text.Replace("[", "[[").Replace("]", "]]");
}