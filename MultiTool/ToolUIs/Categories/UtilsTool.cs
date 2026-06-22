using MultiTool.Language;
using MultiTool.UI;
using Spectre.Console;
using HorizontalAlignment = MultiTool.UI.HorizontalAlignment;
using Keys = MultiTool.Language.Keys;

namespace MultiTool.ToolUIs.Categories;

public class UtilsTool : Frame {
    private Title title;
    private SelectionPrompt<AvailableTool> menu;
    private List<AvailableTool> options;

    public UtilsTool() {
        options = new List<AvailableTool> { 
            AvailableTools.CHATBOT_UTILS,
            AvailableTools.TEXT_CONVERTER_UTILS,
            AvailableTools.HASH_GENERATOR_UTILS,
            AvailableTools.REGEX_TESTER_UTILS,
            AvailableTools.TIME_UTILITIES_UTILS,
            AvailableTools.BACK_TO_MAIN_MENU
        };
        
        title = new Title(Keys.UTILS_MENU, ConsoleColor.Blue, ConsoleColor.Cyan, HorizontalAlignment.CENTER);
        menu  = new SelectionPrompt<AvailableTool>().AddChoices(options);
    }
    
    public override void render() {
        title.render();
        AvailableTool selected = AnsiConsole.Prompt(menu);
        AvailableToolMenu selectedMenu;
        if (selected is AvailableToolMenu) selectedMenu = (AvailableToolMenu) selected;
        else selectedMenu                               = AvailableTools.MAIN_MENU;
        selectedMenu.switchMenu();
    }
}
