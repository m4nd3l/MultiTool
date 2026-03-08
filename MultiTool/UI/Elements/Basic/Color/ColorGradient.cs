using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTool.UI.Elements.Basic.Color;
public class ColorGradient {
    private Color _start;
    private Color _end;

    public ColorGradient(Color start, Color end) {
        _start = start;
        _end = end;
    }

    public Color getStart() {
        return _start;
    }

    public string getColoredString(float progress, float max, string text) {
        progress = Math.Clamp(progress / max, 0f, 1f);

        int r = (int)(_start.getR() + (_end.getR() - _start.getR()) * progress);
        int g = (int)(_start.getG() + (_end.getG() - _start.getG()) * progress);
        int b = (int)(_start.getB() + (_end.getB() - _start.getB()) * progress);

        return $"\x1b[38;2;{r};{g};{b}m{text}\x1b[0m";
    }

    public Color getEnd() {
        return _end;
    }
}

