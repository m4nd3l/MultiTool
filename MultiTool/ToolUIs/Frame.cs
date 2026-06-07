using Spectre.Console;

namespace MultiTool.Tools;

public interface Frame {
    void clear() { AnsiConsole.Clear(); }
}
