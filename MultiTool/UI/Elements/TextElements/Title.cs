using MultiTool.UI.Elements.Basic;
using MultiTool.UI.Elements.Basic.Color;
using System.Text.RegularExpressions;

namespace MultiTool.UI.Elements.TextElements;
public class Title : UIElement {
    private List<string> _text;
    private ColorGradient? _gradient;

    public Title(string text, ColorGradient gradient = null) : base() {
        _text = new List<string>() { text };
        _gradient = gradient;
    }
    public Title(List<string> text, ColorGradient gradient = null) : base() {
        _text = text;
        _gradient = gradient;
    }

    public void display(bool centered) {
        if (_text.Count <= 0) return;
        if (_gradient != null) {
            for (int i = 0; i < _text.Count; i++)
                if (!centered)
                    Console.WriteLine(_gradient.getColoredString(i, _text.Count - 1, _text[i]));
                else
                    printCentered(_gradient.getColoredString(i, _text.Count - 1, _text[i]));
        } else {
            Console.ForegroundColor = getSettings().getTitleText().getTextColor();
            Console.BackgroundColor = getSettings().getTitleText().getBackgroundColor();
            foreach (string line in _text) {
                if (!centered) Console.WriteLine(line);
                else printCentered(line);
            }
        }
        Console.ResetColor();
    }

    private void printCentered(string coloredText) {
        int width = Console.WindowWidth;

        string plainText = Regex.Replace(coloredText, @"\x1b\[[0-9;]*m", "");

        if (plainText.Length >= width) {
            Console.WriteLine(coloredText);
            return;
        }

        int leftPadding = (width - plainText.Length) / 2;
        Console.Write(new string(' ', leftPadding));

        Console.WriteLine(coloredText);
    }
}
