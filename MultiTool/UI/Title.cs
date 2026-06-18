using MultiTool.Extensions;
using MultiTool.Language;
using MultiTool.UI.FiggleFont;
using Spectre.Console;
using Color = Spectre.Console.Color;

namespace MultiTool.UI;

public class Title {
    private string text;
    private Color topColor;
    private Color bottomColor;
    private HorizontalAlignment alignment;

    public Title(Key text) : this(text, Color.White, Color.White, HorizontalAlignment.CENTER) {  }
    public Title(Key text, ConsoleColor color) : this(text, Color.FromConsoleColor(color), HorizontalAlignment.CENTER) {  }
    public Title(Key text, ConsoleColor topColor, ConsoleColor bottomColor) 
        : this(text, Color.FromConsoleColor(topColor), Color.FromConsoleColor(bottomColor), HorizontalAlignment.CENTER) {  }
    public Title(Key text, Color color) : this(text, color, color, HorizontalAlignment.CENTER) {  }
    public Title(Key text, Color topColor, Color bottomColor)
        : this(text, topColor, bottomColor, HorizontalAlignment.CENTER) {  }
    public Title(Key text, HorizontalAlignment alignment) : this(text, Color.White, Color.White, alignment) {  }
    public Title(Key text, ConsoleColor color, HorizontalAlignment alignment) : this(text, Color.FromConsoleColor(color), alignment) {  }
    public Title(Key text, ConsoleColor topColor, ConsoleColor bottomColor, HorizontalAlignment alignment) 
        : this(text, Color.FromConsoleColor(topColor), Color.FromConsoleColor(bottomColor), alignment) {  }
    public Title(Key text, Color color, HorizontalAlignment alignment) : this(text, color, color, alignment) {  }
    public Title(Key text, Color topColor, Color bottomColor, HorizontalAlignment alignment) {
        this.text        = text.translate();
        this.topColor    = topColor;
        this.bottomColor = bottomColor;
        this.alignment   = alignment;
    }

    public void render() {
        if (string.IsNullOrEmpty(text)) return;
        
        string asciiArt = BloodyFont.BLOODY.Render(text);
        string[] lines = asciiArt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        int width = 0;
        foreach (string line in lines) width = Math.Max(width, line.Length);

        int consoleWidth = Console.WindowWidth;
        int leftSpace  = 0;

        switch (alignment) {
            case HorizontalAlignment.CENTER:
                leftSpace  = Math.Max(leftSpace, (consoleWidth - width) / 2);
                break;
            case HorizontalAlignment.RIGHT:
                leftSpace = Math.Max(leftSpace, consoleWidth - width);
                break;
            case HorizontalAlignment.LEFT: break;
        }
        
        for (int i = 0; i < lines.Length; i++) {
            float ratio = lines.Length > 1 ? (float)i / (lines.Length - 1) : 0.0f;
            byte r = (byte)(topColor.R + (bottomColor.R - topColor.R) * ratio);
            byte g = (byte)(topColor.G + (bottomColor.G - topColor.G) * ratio);
            byte b = (byte)(topColor.B + (bottomColor.B - topColor.B) * ratio);

            string padLeft = new string(' ', leftSpace);
            AnsiConsole.MarkupLine(
                $"{padLeft}[#{new Color(r, g, b).ToHex()}]{Markup.Escape(lines[i])}[/]");
        }
    }
}
