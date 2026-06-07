using Spectre.Console;

namespace MultiTool.ToolUIs;

public interface Frame { 
    abstract void render();
    public void clear() { AnsiConsole.Clear(); }
}
