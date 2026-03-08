using MultiTool.UI.Elements.Basic;
using MultiTool.UI.Elements.Basic.Color;
using MultiTool.UI.Elements.Basic.Settings;
using MultiTool.UI.Elements.TextElements;

namespace MultiTool.UI.Elements.Menu;
public class MenuItem  {
    private Text _text;
    private Action<int>? _onClick;
    private int _spaceModifier;

    public MenuItem(string text, Color? color = null, Action<int>? onClick = null, int spaceModifier = 0) {
        _text = new Text(text, color);
        _onClick = onClick;
        _spaceModifier = spaceModifier;
    }

    public void display(int? index, int contentWidth, bool selected = false, bool centerItem = true, int padding = -1, string box = "") {
        string prefix = selected ? "> " : "  ";
        string s_index = index != null ? $"{index}. " : "";
        string textToDisplay = prefix + s_index + _text.getText();
        printColored(new Text(textToDisplay, _text.getColor()), centerItem, selected, padding, box, contentWidth);
    }

    private void printCentered(Text text, bool selected, int padding, string box, int contentWidth) {
        int width = Console.WindowWidth;
        string rawText = text.getText();

        string eventualSpace = box != "" ? " " : "";

        if (rawText.Length >= width) {
            Console.WriteLine(text.getColored());
            return;
        }

        if (padding == -1) padding = (width - rawText.Length) / 2;
        Console.Write(new string(' ', padding));

        if (selected) {
            Console.ForegroundColor = getSettings().getSelectedText().getTextColor();
            Console.BackgroundColor = getSettings().getSelectedText().getBackgroundColor();
        }
        string space = new string(' ', contentWidth - text.getText().Length - 1 + _spaceModifier);
        Console.WriteLine($"{box}{eventualSpace}{text.getColored()}{space}{box}");
        Console.ResetColor();
    }

    private void printColored(Text text, bool centered, bool selected, int padding, string box, int contentWidth) {
        if (centered) {
            printCentered(text, selected, padding, box, contentWidth);
        } else {
            if (selected) {
                Console.ForegroundColor = getSettings().getSelectedText().getTextColor();
                Console.BackgroundColor = getSettings().getSelectedText().getBackgroundColor();
            }
            string eventualSpace = box != "" ? " " : "";
            string space = new string(' ', contentWidth - text.getText().Length - 1 + _spaceModifier);
            Console.WriteLine($"{box}{eventualSpace}{text.getColored()}{space}{box}");
            Console.ResetColor();
        }
    }
    public void click(int index) {
        if (_onClick == null)
            return;
        _onClick.Invoke(index);
    }
    public int GetFullWidth(int? index, bool selected) {
        string prefix = selected ? "> " : "";
        string s_index = index != null ? $"{index}. " : "";
        return (prefix + s_index + _text.getText()).Length;
    }

    public void setOnClick(Action<int> onClick) {
        _onClick = onClick;
    }
    public void setText(Text text) {
        _text = text;
    }
    public Text getTextObj() {
        return _text;
    }
    public string getText() {
        return _text.getText();
    }
    private UISettings getSettings() { return GlobalSettings.getSettings(); }

}
