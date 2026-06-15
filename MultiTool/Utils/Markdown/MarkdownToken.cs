namespace MultiTool.Utils.Markdown;

public class MarkdownToken {
    public MarkdownTokenType type;
    public string    value;

    public MarkdownToken(MarkdownTokenType type, string value) {
        this.type  = type;
        this.value = value;
    }

    public MarkdownTokenType getType() => type;
    public string getValue() => value;
    
    public override string ToString() { return $"[{getType()}]: \"{getValue()}\""; }
}