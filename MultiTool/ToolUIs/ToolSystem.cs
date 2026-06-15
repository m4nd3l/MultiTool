using System.Security.Cryptography;

namespace MultiTool.ToolUIs;

public class ToolSystem {
    private static Frame? currentFrame;
    public static void startUI() {
        if (currentFrame != null) {
            currentFrame.clear();
            currentFrame = null;
        }

        AvailableTools.MAIN_MENU.switchMenu();
    }

    public static void changeFrame(Frame frame) {
        currentFrame = frame;
        currentFrame.clear();
        currentFrame.render();
    }
}
