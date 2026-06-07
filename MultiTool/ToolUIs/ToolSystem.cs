namespace MultiTool.Tools;

public class ToolSystem {
    private static MainMenu? mainMenu;
    private static Frame? currentFrame;
    public static void startUI() {
        if (mainMenu == null) mainMenu = new ();
        if (currentFrame != null) {
            currentFrame.clear();
            currentFrame = null;
        }
        
        mainMenu.render();
    }
}
