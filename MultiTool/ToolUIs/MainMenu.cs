using MultiTool.UI;
using Spectre.Console;

namespace MultiTool.Tools;

public class MainMenu {
    private SelectionPrompt<AvailableTool> menu;
    private Title title;

    public MainMenu() {
        menu = new SelectionPrompt<AvailableTool>().AddChoices(
            AvailableTools.UTILS_MENU,
            AvailableTools.SYSTEM_MENU,
            AvailableTools.STORAGE_MENU,
            AvailableTools.NETWORK_MENU,
            AvailableTools.DIAGNOSTICS_MENU,
            AvailableTools.EMERGENCY_MENU,
            AvailableTools.HELP_MENU,
            AvailableTools.SETTINGS_MENU,
            AvailableTools.EXIT_MENU
        );
        title = new Title(AvailableTools.MAIN_MENU, ConsoleColor.Red, ConsoleColor.Yellow);
    }
    
    public void render() {
        title.render();
        //AvailableTool selected = AnsiConsole.Prompt(menu);
    }
}
