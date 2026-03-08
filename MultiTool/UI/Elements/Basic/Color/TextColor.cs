using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTool.UI.Elements.Basic.Color;
public class TextColor {
    private ConsoleColor _text;
    private ConsoleColor _background;

    public TextColor(ConsoleColor text, ConsoleColor background) {
        _text = text;
        _background = background;
    }

    public ConsoleColor getTextColor() {
        return _text;
    }
    public ConsoleColor getBackgroundColor() {
        return _background;
    }
    public void setTextColor(ConsoleColor text) {
        _text = text;
    }
    public void setBackgroundColor(ConsoleColor background) {
        _background = background;
    }
}

