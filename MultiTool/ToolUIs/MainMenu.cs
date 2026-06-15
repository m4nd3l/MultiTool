using MultiTool.Language;
using MultiTool.UI;
using Spectre.Console;
using HorizontalAlignment = MultiTool.UI.HorizontalAlignment;

namespace MultiTool.ToolUIs;

public class MainMenu : Frame {
    private Title title;
    private SelectionPrompt<AvailableToolMenu> menu;
    private List<AvailableToolMenu> options;
    private int maxChoiceLength;
    private string choicesPadding;
    public MainMenu() {
        options = new List<AvailableToolMenu> { 
            AvailableTools.UTILS_MENU,
            AvailableTools.SYSTEM_MENU,
            AvailableTools.STORAGE_MENU,
            AvailableTools.NETWORK_MENU,
            AvailableTools.DIAGNOSTICS_MENU,
            AvailableTools.EMERGENCY_MENU,
            AvailableTools.HELP_MENU,
            AvailableTools.SETTINGS_MENU,
            AvailableTools.SAFE_CLOSE_EXIT
        };
        
        foreach (AvailableToolMenu option in options) maxChoiceLength = Math.Max(maxChoiceLength, option.ToString().Length);
        
        int leftSpaceChoices = Math.Max(0, (Console.WindowWidth - (maxChoiceLength + 2)) / 2);
        choicesPadding = new string(' ', leftSpaceChoices);
        
        title = new Title(TranslationKeys.MAIN_MENU, ConsoleColor.Red, ConsoleColor.Yellow, HorizontalAlignment.CENTER);
        menu  = new SelectionPrompt<AvailableToolMenu>()
            .UseConverter(choice => $"{choicesPadding}{choice}")
            .AddChoices(options);
    }
    
    public override void render() {
        AnsiConsole.Clear();
        title.render();
        AvailableToolMenu selected = AnsiConsole.Prompt(menu);
        selected.switchMenu();
        AnsiConsole.Clear();
    }
}
