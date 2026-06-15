using System.Text;
using System.Text.RegularExpressions;

namespace MultiTool.Utils.Markdown;

public class MarkdownLexer {
    private bool isInCodeBlock;
    private string currentLanguage = string.Empty;
    private StringBuilder codeBlockBuffer = new StringBuilder();

    public List<MarkdownToken> tokenize(string input) {
        List<MarkdownToken> tokens = new List<MarkdownToken>();
        string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++) {
            string line = lines[i];

            if (isInCodeBlock) {
                if (line.TrimStart().StartsWith("```")) {
                    tokens.Add(new MarkdownCodeToken(MarkdownTokenType.MULTILINE_CODE, codeBlockBuffer.ToString(), currentLanguage)); // CHANGED THIS LINE
                    codeBlockBuffer.Clear();
                    isInCodeBlock = false;
                    currentLanguage = string.Empty;
                } 
                else codeBlockBuffer.AppendLine(line);
                continue;
            }

            if (line.TrimStart().StartsWith("```")) {
                string fence = line.TrimStart();
                currentLanguage = fence.Length > 3 ? fence.Substring(3).Trim() : string.Empty;
                isInCodeBlock = true;
                continue;
            }

            tokenizeLineBlock(line, tokens, lines, i);

            if (i < lines.Length - 1) tokens.Add(new MarkdownToken(MarkdownTokenType.NEW_LINE, "\n"));
        }

        return tokens;
    }

    private void tokenizeLineBlock(string line, List<MarkdownToken> tokens, string[] lines, int currentIndex) {
        string trimmed = line.Trim();

        if (string.IsNullOrEmpty(trimmed)) return;

        if (trimmed == "---" || trimmed == "***" || trimmed == "___") {
            tokens.Add(new MarkdownToken(MarkdownTokenType.HORIZONTAL_RULE, trimmed));
            return;
        }

        if (trimmed.StartsWith("#")) {
            int hashCount = 0;
            while (hashCount < trimmed.Length && trimmed[hashCount] == '#') hashCount++;

            if (hashCount <= 6 && hashCount < trimmed.Length && trimmed[hashCount] == ' ') {
                MarkdownTokenType headingType = (MarkdownTokenType)(hashCount - 1);
                string content = trimmed.Substring(hashCount + 1);
                tokens.Add(new MarkdownToken(headingType, content));
                return;
            }
        }

        if (trimmed.StartsWith(">")) {
            tokens.Add(new MarkdownToken(MarkdownTokenType.BLOCKQUOTE, ">"));
            tokenizeInline(line.Substring(line.IndexOf('>') + 1), tokens);
            return;
        }

        if (trimmed.StartsWith("[^") && trimmed.Contains("]:")) {
            int closeIndex = trimmed.IndexOf("]:");
            tokens.Add(new MarkdownToken(MarkdownTokenType.FOOT_NOTE_DEFINITION, trimmed.Substring(0, closeIndex + 2)));
            tokenizeInline(trimmed.Substring(closeIndex + 2), tokens);
            return;
        }

        if (trimmed.StartsWith(":")) {
            tokens.Add(new MarkdownToken(MarkdownTokenType.DEFINITION_DESCRIPTION, ":"));
            tokenizeInline(line.Substring(line.IndexOf(':') + 1), tokens);
            return;
        }

        if (trimmed.StartsWith("- [x] ") || trimmed.StartsWith("- [X] ")) {
            tokens.Add(new MarkdownToken(MarkdownTokenType.TASK_LIST_ITEM_CHECKED, "- [x]"));
            tokenizeInline(trimmed.Substring(6), tokens);
            return;
        }

        if (trimmed.StartsWith("- [ ] ")) {
            tokens.Add(new MarkdownToken(MarkdownTokenType.TASK_LIST_ITEM_UNCHECKED, "- [ ]"));
            tokenizeInline(trimmed.Substring(6), tokens);
            return;
        }

        if (trimmed.StartsWith("- ") || trimmed.StartsWith("* ") || trimmed.StartsWith("+ ")) {
            tokens.Add(new MarkdownToken(MarkdownTokenType.UNORDERED_LIST_ITEM, trimmed.Substring(0, 2)));
            tokenizeInline(trimmed.Substring(2), tokens);
            return;
        }

        if (Regex.IsMatch(trimmed, @"^\d+\.\s")) {
            int matchLength = Regex.Match(trimmed, @"^\d+\.\s").Length;
            tokens.Add(new MarkdownToken(MarkdownTokenType.ORDERED_LIST_ITEM, trimmed.Substring(0, matchLength)));
            tokenizeInline(trimmed.Substring(matchLength), tokens);
            return;
        }

        if (trimmed.StartsWith("|") && trimmed.EndsWith("|")) {
            tokens.Add(new MarkdownToken(MarkdownTokenType.TABLE_ROW, trimmed));
            return;
        }

        if (currentIndex < lines.Length - 1 && lines[currentIndex + 1].Trim().StartsWith(":")) {
            tokens.Add(new MarkdownToken(MarkdownTokenType.DEFINITIONT_ERM, trimmed));
            return;
        }

        tokenizeInline(line, tokens);
    }

    private void tokenizeInline(string text, List<MarkdownToken> tokens) {
        int index = 0;
        StringBuilder textBuffer = new StringBuilder();

        while (index < text.Length) {
            if (index + 1 < text.Length && text.Substring(index, 2) == "**") {
                flushTextBuffer(textBuffer, tokens);
                processClosingPair(text, ref index, "**", MarkdownTokenType.BOLD, tokens);
                continue;
            }
            if (index + 1 < text.Length && text.Substring(index, 2) == "~~") {
                flushTextBuffer(textBuffer, tokens);
                processClosingPair(text, ref index, "~~", MarkdownTokenType.STRIKETHROUGH, tokens);
                continue;
            }
            if (index + 1 < text.Length && text.Substring(index, 2) == "==") {
                flushTextBuffer(textBuffer, tokens);
                processClosingPair(text, ref index, "==", MarkdownTokenType.HIGHLIGHT, tokens);
                continue;
            }
            if (text[index] == '*' || text[index] == '_') {
                flushTextBuffer(textBuffer, tokens);
                string wrapper = text[index].ToString();
                processClosingPair(text, ref index, wrapper, MarkdownTokenType.ITALIC, tokens);
                continue;
            }
            if (text[index] == '`') {
                flushTextBuffer(textBuffer, tokens);
                processClosingPair(text, ref index, "`", MarkdownTokenType.CODE_IN_LINE, tokens);
                continue;
            }
            if (text[index] == '~') {
                flushTextBuffer(textBuffer, tokens);
                processClosingPair(text, ref index, "~", MarkdownTokenType.SUBSCRIPT, tokens);
                continue;
            }
            if (text[index] == '^') {
                flushTextBuffer(textBuffer, tokens);
                processClosingPair(text, ref index, "^", MarkdownTokenType.SUPERSCRIPT, tokens);
                continue;
            }
            if (text[index] == ':' && index + 1 < text.Length) {
                int nextColon = text.IndexOf(':', index + 1);
                if (nextColon != -1 && !text.Substring(index, nextColon - index + 1).Contains(" ")) {
                    flushTextBuffer(textBuffer, tokens);
                    tokens.Add(new MarkdownToken(MarkdownTokenType.EMOJI, text.Substring(index, nextColon - index + 1)));
                    index = nextColon + 1;
                    continue;
                }
            }
            if (index + 1 < text.Length && text.Substring(index, 2) == "![") {
                int closeBracket = text.IndexOf(']', index + 2);
                if (closeBracket != -1 && closeBracket + 1 < text.Length && text[closeBracket + 1] == '(') {
                    int closeParen = text.IndexOf(')', closeBracket + 2);
                    if (closeParen != -1) {
                        flushTextBuffer(textBuffer, tokens);
                        tokens.Add(new MarkdownToken(MarkdownTokenType.IMAGE, text.Substring(index, closeParen - index + 1)));
                        index = closeParen + 1;
                        continue;
                    }
                }
            }
            if (text[index] == '[') {
                int closeBracket = text.IndexOf(']', index + 1);
                if (closeBracket != -1 && closeBracket + 1 < text.Length && text[closeBracket + 1] == '(') {
                    int closeParen = text.IndexOf(')', closeBracket + 2);
                    if (closeParen != -1) {
                        flushTextBuffer(textBuffer, tokens);
                        tokens.Add(new MarkdownToken(MarkdownTokenType.LINK, text.Substring(index, closeParen - index + 1)));
                        index = closeParen + 1;
                        continue;
                    }
                }
                if (closeBracket != -1 && text.Substring(index + 1, closeBracket - index - 1).StartsWith("^")) {
                    flushTextBuffer(textBuffer, tokens);
                    tokens.Add(new MarkdownToken(MarkdownTokenType.FOOT_NOTE_REFERENCE, text.Substring(index, closeBracket - index + 1)));
                    index = closeBracket + 1;
                    continue;
                }
            }

            textBuffer.Append(text[index]);
            index++;
        }

        flushTextBuffer(textBuffer, tokens);
    }

    private void processClosingPair(string text, ref int index, string delimiter, MarkdownTokenType type, List<MarkdownToken> tokens) {
        int startPos = index + delimiter.Length;
        int endPos = text.IndexOf(delimiter, startPos);
        if (endPos != -1) {
            tokens.Add(new MarkdownToken(type, text.Substring(startPos, endPos - startPos)));
            index = endPos + delimiter.Length;
        } 
        else {
            tokens.Add(new MarkdownToken(MarkdownTokenType.TEXT, delimiter));
            index += delimiter.Length;
        }
    }

    private void flushTextBuffer(StringBuilder textBuffer, List<MarkdownToken> tokens) {
        if (textBuffer.Length > 0) {
            tokens.Add(new MarkdownToken(MarkdownTokenType.TEXT, textBuffer.ToString()));
            textBuffer.Clear();
        }
    }
}