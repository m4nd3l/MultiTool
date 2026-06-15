using MultiTool;
using MultiTool.Language;
using MultiTool.ToolUIs;

public class MultiToolProgram {
    public static void Main(string[] args) {
        // TODO: add support for direct-access via args to tools
        MultiToolSaving.init();
        LanguageManager.init();
        ToolSystem.startUI();
    }
}