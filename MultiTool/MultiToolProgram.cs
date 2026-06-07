using MultiTool.Language;
using MultiTool.ToolUIs;

public class MultiToolProgram {
    public static void Main(string[] args) {
        // TODO: add support for direct-access via args to tools
        LanguageManager.init();
        ToolSystem.startUI();
    }
}