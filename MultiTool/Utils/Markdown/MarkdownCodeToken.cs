namespace MultiTool.Utils.Markdown;

public class MarkdownCodeToken : MarkdownToken {
    private string language;
    public MarkdownCodeToken(MarkdownTokenType type, string value, string language) : base(type, value) { this.language = language; }
    public string getLanguage() => language;
}
