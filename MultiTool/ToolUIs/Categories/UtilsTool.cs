using ABI.System.Collections.Generic;
using MultiTool.Language;
using MultiTool.UI;
using Spectre.Console;
using HorizontalAlignment = MultiTool.UI.HorizontalAlignment;

namespace MultiTool.ToolUIs.Categories;

public class UtilsTool : Frame {
    private Title title;
    private SelectionPrompt<AvailableTool> menu;
    private List<AvailableTool> options;
    private int maxChoiceLength;
    private string choicesPadding;
    public UtilsTool() {
        options = new List<AvailableTool> { 
            AvailableTools.CHATBOT_UTILS,
            AvailableTools.BACK_TO_MAIN_MENU
        };
        
        foreach (AvailableTool option in options) maxChoiceLength = Math.Max(maxChoiceLength, option.ToString().Length);
        
        int leftSpaceChoices = Math.Max(0, (Console.WindowWidth - (maxChoiceLength + 2)) / 2);
        choicesPadding = new string(' ', leftSpaceChoices);
        
        title = new Title(TranslationKeys.UTILS_MENU, ConsoleColor.Blue, ConsoleColor.Cyan, HorizontalAlignment.CENTER);
        menu  = new SelectionPrompt<AvailableTool>()
            .UseConverter(choice => $"{choicesPadding}{choice}")
            .AddChoices(options);
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
