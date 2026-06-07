using Figgle;
using Figgle.Fonts;
using MultiTool.UI.FiggleFont;
using Spectre.Console;

namespace MultiTool.UI;

public class Title {
    private AvailableTool tool;
    private Color topColor;
    private Color bottomColor;

    public Title(AvailableTool tool) : this(tool, ConsoleColor.White, ConsoleColor.White) {  }
    public Title(AvailableTool tool, ConsoleColor color) : this(tool, Color.FromConsoleColor(color)) {  }
    public Title(AvailableTool tool, ConsoleColor topColor, ConsoleColor bottomColor) 
        : this(tool, Color.FromConsoleColor(topColor), Color.FromConsoleColor(bottomColor)) {  }
    public Title(AvailableTool tool, Color color) : this(tool, color, color) {  }
    public Title(AvailableTool tool, Color topColor, Color bottomColor) {
        this.tool        = tool;
        this.topColor    = topColor;
        this.bottomColor = bottomColor;
    }

    public void render() {
        string? toolName = tool.ToString()?.ToUpper();
        if (string.IsNullOrEmpty(toolName)) return;
        
        string asciiArt = BloodyFont.BLOODY.Render(toolName);
        string[] lines = asciiArt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        Color start = Color.FromConsoleColor(topColor);
        Color end = Color.FromConsoleColor(bottomColor);

        for (int i = 0; i < lines.Length; i++) {
            float ratio = lines.Length > 1 ? (float)i / (lines.Length - 1) : 0.0f;
            byte r = (byte)(start.R + (end.R - start.R) * ratio);
            byte g = (byte)(start.G + (end.G - start.G) * ratio);
            byte b = (byte)(start.B + (end.B - start.B) * ratio);

            AnsiConsole.MarkupLine($"[#{new Color(r, g, b).ToHex()}]{Markup.Escape(lines[i])}[/]");
        }
    }
}
