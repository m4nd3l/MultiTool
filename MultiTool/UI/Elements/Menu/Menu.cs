using MultiTool.UI.Elements.Basic;
using MultiTool.UI.Elements.Basic.Color;
using MultiTool.UI.Elements.TextElements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.VoiceCommands;

namespace MultiTool.UI.Elements.Menu;
public class Menu : UIElement {
    private Title _title;
    private List<MenuItem> _items;
    private bool _indexed;
    private bool _centerTitle;
    private bool _centerItems;
    private bool _outline;
    private bool _pressedEnter = false;
    private int _selected = 0;
    private int _padding = 0;
    private int _currentPersistedSelection = -1;

    public Menu(Title title, List<MenuItem> items, bool indexed = true, bool centerTitle = true, 
        bool centerItems = true, bool outline = true, int? selected = null) : base() {
        _title = title;
        _items = items;
        _indexed = indexed;
        _centerTitle = centerTitle;
        _centerItems = centerItems;
        _outline = outline;
        if (selected != null) {
            _selected = selected.Value;
            _currentPersistedSelection = _selected;
            _items[_selected].setText(new Text(_items[_selected].getText(), color: new Color(Colors.Cyan)));
        }
    }

    public int run(Action? renderOther = null, int? index = null) {
        _pressedEnter = false;
        if (index != null) _selected = index.Value; 
        calculatePadding(_centerItems);
        while (!_pressedEnter) {
            render(_centerTitle, _centerItems);
            renderOther?.Invoke();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow) 
                decreaseIndex();
            else if (keyInfo.Key == ConsoleKey.DownArrow) 
                increaseIndex();
            else if (keyInfo.Key == ConsoleKey.Enter) {
                _pressedEnter = true;
                _items[_selected].click(_selected);
                return _selected;
            }
        }
        return _selected;
    }

    private void render(bool centerTitle = true, bool centerItems = true) {
        Console.Clear();

        _title.display(centerTitle);
        Console.WriteLine();

        char verticalLine   = '║';
        char horizontalLine = '═';
        char topRight       = '╗';
        char bottomRight    = '╝';
        char topLeft        = '╔';
        char bottomLeft     = '╚';

        int contentWidth = getMaxContentWidth();

        if (_outline) 
            Console.WriteLine($"{new string(' ', _padding)}{topLeft}{new string(horizontalLine, contentWidth)}{topRight}");

        for (int i = 0; i < _items.Count; i++)
            _items[i].display(i + 1, contentWidth, i == _selected, centerItems, _padding, _outline && i < _items.Count ? $"{verticalLine}" : "");

        if (_outline) 
            Console.WriteLine($"{new string(' ', _padding)}{bottomLeft}{new string(horizontalLine, contentWidth)}{bottomRight}");
        
    }

    private void calculatePadding(bool centerItems) {
        if (centerItems) {
            int maxContentWidth = getMaxContentWidth();

            int windowWidth = Console.WindowWidth;
            int outline = _outline ? 4 : 2;
            _padding = Math.Max(0, (windowWidth - maxContentWidth + outline) / 2);
        } else {
            _padding = -1;
        }
    }

    private int getMaxContentWidth() {
        if (!_items.Any())
            return 0;

        return _items.Select((item, index) => {
            string text = item.getText();
            int prefixWidth = 2; // for "> "
            int indexWidth = _indexed ? $"{index}. ".Length : 0;
            int spacing = 2;
            return text.Length + prefixWidth + indexWidth + spacing + 1;
        }).Max();
    }

    private void increaseIndex() {
        if (_selected < _items.Count - 1) _selected++;
        else _selected = 0;
    }
    private void decreaseIndex() {
        if (_selected > 0) _selected--;
        else _selected = _items.Count - 1;
    }

    public void setTitle(Title title) {
        _title = title;
    }
    public void setSelected(int selected) {
        if (_currentPersistedSelection != -1) 
            _items[_currentPersistedSelection].setText(new Text(_items[_currentPersistedSelection].getText()));
        _selected = selected;
        _currentPersistedSelection = selected;
        _items[_selected].setText(new Text(_items[_selected].getText(), color: new Color(Colors.Cyan)));
    }
    public void setItems(List<MenuItem> items) {
        _items = items;
    }
    public Title getTitle() {
        return _title;
    }
    public MenuItem getSelected() {
        return _items[_selected];
    }
}

