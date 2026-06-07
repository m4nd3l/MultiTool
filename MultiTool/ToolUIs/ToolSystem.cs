namespace MultiTool.ToolUIs;

public class ToolSystem {
    private static Frame? currentFrame;
    public static void startUI() {
        if (currentFrame != null) {
            currentFrame.clear();
            currentFrame = null;
        }

        AvailableTools.MAIN_MENU.getMenu().render();
    }
}
