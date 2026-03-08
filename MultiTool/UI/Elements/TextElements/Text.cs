using MultiTool.UI.Elements.Basic;
using MultiTool.UI.Elements.Basic.Color;

namespace MultiTool.UI.Elements.TextElements;
public class Text : UIElement {
    private string _text;
    private Color? _color;

    public Text(string text, Color? color = null) : base() {
        _text = text;
        _color = color;
    }

    public string getColored() {
        if (_color == null) return _text;
        return _color.getAnsiCode(_text);
    }

    public void display(bool centered = true, bool newLine = true) {
        string coloredText = getColored();
        if (centered) {
            int consoleWidth = Console.WindowWidth;
            int textLength = _text.Length;
            int padding = Math.Max(0, (consoleWidth - textLength) / 2);
            if (newLine) Console.WriteLine(new string(' ', padding) + coloredText);
            else Console.Write(new string(' ', padding) + coloredText);
        } else {
            if (newLine) Console.WriteLine(coloredText);
            else Console.Write(coloredText);
        }
    }

    public void setText(string text) {
        _text = text;
    }

    public string getText() {
        return _text;
    }
    public Color getColor() {
        return _color;
    }
}
