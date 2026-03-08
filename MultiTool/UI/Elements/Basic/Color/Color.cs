namespace MultiTool.UI.Elements.Basic.Color;
public class Color {
    private float _r;
    private float _g;
    private float _b;

    public Color(float r, float g, float b) {
        _r = r;
        _g = g;
        _b = b;
    }

    public Color(Colors colorEnum) {
        (_r, _g, _b) = colorEnum switch {
            Colors.Black => (0, 0, 0),
            Colors.DarkBlue => (0, 0, 128),
            Colors.DarkGreen => (0, 128, 0),
            Colors.DarkCyan => (0, 128, 128),
            Colors.DarkRed => (128, 0, 0),
            Colors.DarkMagenta => (128, 0, 128),
            Colors.DarkYellow => (128, 128, 0),
            Colors.Gray => (192, 192, 192),
            Colors.DarkGray => (128, 128, 128),
            Colors.Blue => (0, 0, 255),
            Colors.Green => (0, 255, 0),
            Colors.Cyan => (0, 255, 255),
            Colors.Red => (255, 0, 0),
            Colors.Magenta => (255, 0, 255),
            Colors.Yellow => (255, 255, 0),
            Colors.White => (255, 255, 255),
            _ => (0, 0, 0)
        };
    }

    public string getAnsiCode(string text) {
        return $"\x1b[38;2;{getR()};{getG()};{getB()}m{text}\x1b[0m";
    }

    public float getR() { return _r; }
    public float getG() { return _g; }
    public float getB() { return _b; }

    public override bool Equals(object? obj) {
        return obj is Color color &&
               _r == color._r &&
               _g == color._g &&
               _b == color._b;
    }
}

