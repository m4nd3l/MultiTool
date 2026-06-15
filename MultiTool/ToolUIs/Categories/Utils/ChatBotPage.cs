using Google.GenAI;
using Google.GenAI.Types;
using MultiTool.Extensions;
using MultiTool.Language;
using MultiTool.UI;
using Spectre.Console;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MultiTool.ToolUIs.Categories.Utils;

public class ChatBotPage : Frame {
    private Title title;
    private Client? geminiClient;
    private string geminiModel = "gemini-3.5-flash";
    private string promptHeader = 
        """
        # SYSTEM INSTRUCTIONS: MultiTool CLI Assistant — Formatting System
        
        You are the AI engine for MultiTool. You must NEVER use standard Markdown formatting (`**`, `*`, `~~`, `#`, headers, or HTML tags) for text styling, as it breaks the terminal view or throws a `System.InvalidOperationException`. 
        
        Instead, you must strictly map standard text formats to Spectre.Console markup tags (`[style]text[/]`).
        
        ## Markdown-to-Spectre Conversion Reference
        
        Use this exact mapping guide whenever you need to format your console responses:
        
        ### 1. Headers & Titles
        Do not use `#`. Use explicit color and bold tags to separate sections:
        * H1 Header: `[bold rgb(255,165,0)]Your Title Here[/]`
        * H2 Header: `[bold yellow]Your Subtitle Here[/]`
        * H3 Header: `[bold cyan]Minor Section Here[/]`
        
        ### 2. Basic Text Styles
        * Bold: `[bold]strong emphasis[/]`
        * Italic / Cursive: `[italic]emphasis[/]`
        * Bold & Italic: `[bold][italic]extreme emphasis[/][/]`
        * Strikethrough: `[strikethrough]deleted text[/]`
        * Underline: `[underline]underlined text[/]`
        * Dim / Muted: `[dim]secondary text[/]`
        * Inverted Text: `[invert]reversed colors[/]`
        * Color: `[green]different color[/]`
            PS: DO NOT use purple, you can use fuchsia, magenta or rgb(128,0,128) instead.
        
        ### 3. Functional Elements
        * Inline Code / Code Snippet: Wrap in grey or use a distinct color. Example: `[rgb(135,175,215)]my_variable[/]` or `[grey]Console.WriteLine()[/]`
        * Keyboard Shortcuts: `[black on white] Ctrl [/] + [black on white] C [/]`
        * Hyperlinks: `[link=https://example.com]Click Here[/]` or explicit link output: `[link]https://example.com[/]`
        
        ### 4. Custom List & Table Simulation
        * Bullet Points: Use literal terminal characters like `•` or `*` without markdown syntax.
        * Checkboxes: Use text characters: `[[ ]] Unchecked` and `[[[green]X[/]]] Checked`
        * Tables / Blockquotes: Draw them out manually using pure text block characters (e.g., `│`, `┌`, `└`, `┃`) combined with color/style tags inside the cell rows.
        
        ### 5. Escaping Brackets (CRITICAL)
        If you want to print a literal square bracket `[` character without treating it as a markup command, you MUST double it:
        * To output `[text]`, you must write: `[[text]`
        * To output the literal string `[bold]`, you must write: `[[bold]]`
        
        ### 6. Multiline Code Blocks
        Standard Markdown code blocks (using triple backticks ```) are permitted *only* when providing raw blocks of code or scripts to the user, 
        as the MultiTool application parses them natively using Spectre's `SyntaxHighlighter`.
        Do not write the code language after the backticks.
        If you need to manually color or draw custom text blocks instead of a standard code panel, format them using explicit text borders:
        ```
        ┌────────────────────────────────────────────────────────┐
        │public void InitializeMultiTool() {                     │
        │    if (isConfigured) return;                           │
        │    Console.WriteLine("System Ready");                  │
        │}                                                       │
        └────────────────────────────────────────────────────────┘
        ```
        
        ### 7. Line Breaks & Closed Tags (CRITICAL)
        * NEVER split a markup tag across multiple lines. Every open tag `[style]` must be closed with `[/]` on the exact same line before a newline (`\n`) character occurs.
        * Do not leave unclosed tags spanning paragraphs.
        
        Please use Spectre.Console markup tags, do not strictly follow what I said before, just do not use markup like you would normally do.
        REMEMBER TO CLOSE TAGS!
        Close tags the correct way: `[green]different color[/]`, NOT `[green]different color[/green]`
        If you have to close something like `[[This is inside literal brackets`, please use `]]` to close.

""";
    private Dictionary<string, string> chatHistory;

    public ChatBotPage() {
        title      = new Title(TranslationKeys.CHATBOT_UTILS, ConsoleColor.Cyan, ConsoleColor.White);
        string api = getAPIKey();
        if (!string.IsNullOrEmpty(api)) geminiClient = new Client(apiKey: api);
        chatHistory = new  Dictionary<string, string>();
    }
    
    public override void render() {
        title.render();
        AnsiConsole.Write(new Text(this.translate(TranslationKeys.EXIT_TO_CLOSE_CHATBOT)) { Justification = Justify.Center });
        AnsiConsole.WriteLine();
        string currentPrompt;
        Style loadingStyle = Style.Parse("yellow bold");
        while (true) {
            currentPrompt = AnsiConsole.Prompt(new InputMessage());
            if (currentPrompt.Equals(this.translate(TranslationKeys.EXIT), StringComparison.OrdinalIgnoreCase)) break;
            if (currentPrompt.Equals(this.translate(TranslationKeys.HELP_MENU), StringComparison.OrdinalIgnoreCase)) {
                AnsiConsole.Write(new Text(this.translate(TranslationKeys.EXIT_TO_CLOSE_CHATBOT)));
                continue;
            }
            
            SentMessage? response = null;
            bool succeded = false;
            Console.SetCursorPosition(0, Console.CursorTop);
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Dots)
                .SpinnerStyle(loadingStyle)
                .StartAsync(this.translate(TranslationKeys.LOADING_ANSWER_CHATBOT),
                            _ => {
                                var task = Task.Run(() => geminiRequest(currentPrompt));
                                task.Wait();
                                (response, succeded) = task.Result;
                                return Task.CompletedTask;
                            });
            if (succeded && response != null) {
                response.render();
                chatHistory.Add($"Prompt#{chatHistory.Count + 1}: {currentPrompt}", $"Answer#{chatHistory.Count + 1}: {response.getMessage()}");
            } else chatHistory.Add($"Prompt#{chatHistory.Count + 1}: {currentPrompt}", $"Answer#{chatHistory.Count + 1}: No answer");
            AnsiConsole.WriteLine();
        }
        AvailableTools.MAIN_MENU.switchMenu();
    }

    private async Task<(SentMessage, bool)> geminiRequest(string prompt) {
        if (geminiClient == null) {
            while (true) {
                AnsiConsole.Write(new Text(this.translate(TranslationKeys.API_KEY_NOT_FOUND_OR_VALID_CHATBOT) + "\n", Color.Red));
                string apiKey = AnsiConsole.Ask<string>(this.translate(TranslationKeys.ASK_API_KEY_CHATBOT));
                if (string.IsNullOrEmpty(apiKey)) continue;
                try { geminiClient = new Client(apiKey: apiKey); } catch { continue; }
                break;
            }
        }
        string? answer = null;
        bool succeded = true;
        try {
            string completeInput = $"{promptHeader}\n\nCHAT HISTORY: {JsonSerializer.Serialize(chatHistory)}\n\nUSER PROMPT: {prompt}";
            while (completeInput.Length >= 4000000) {
                for (int i = 0; i < 10; i++) {
                    chatHistory.Remove(c);
                }
            }
            GenerateContentResponse response = await geminiClient.Models.GenerateContentAsync(model: geminiModel, contents: completeInput);
            answer = response.Candidates?[0].Content?.Parts?[0].Text;
        } catch (ServerError) {
            AnsiConsole.Write(new Rule("[red]Server Busy[/]") { Justification = Justify.Left });
            AnsiConsole.MarkupLine("[yellow]Gemini models are experiencing high demand right now. Please wait a moment and try your request again.[/]");
            succeded = false;
        } catch (ClientError) {
            AnsiConsole.Write(new Rule("[red]Limit reached[/]") { Justification = Justify.Left });
            AnsiConsole.MarkupLine("[yellow]The maximum limit has been reached, please upgrade your plan or try later to continue.[/]");
            succeded = false;
        }
        catch (Exception ignored) { 
            AnsiConsole.Write(new Rule("[red]API Connection Error[/]") { Justification = Justify.Left });
            AnsiConsole.WriteException(ignored, ExceptionFormats.ShortenEverything);
            succeded = false;
        }
        
        if (string.IsNullOrEmpty(answer)) answer = this.translate(TranslationKeys.REQUEST_ERROR_CHATBOT);
        return (new SentMessage("Gemini", Color.Blue, sanitizeMarkup(answer)), succeded);
    }
    
    private string sanitizeMarkup(string input) {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;
        try { _ = new Markup(input); return input; }
        catch (Exception exception) { AnsiConsole.WriteException(exception); return Markup.Remove(input); }
    }
}
