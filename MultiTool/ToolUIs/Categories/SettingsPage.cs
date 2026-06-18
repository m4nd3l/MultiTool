using ABI.Windows.Security.Authentication.OnlineId;
using MultiTool.Language;
using MultiTool.UI;
using Spectre.Console;

namespace MultiTool.ToolUIs.Categories;

public class SettingsPage : Frame {
    private Title title;
    private SelectionPrompt<AvailableTool> settings;
    private List<AvailableTool> settingsList;

    public SettingsPage() {
        title = new Title(TranslationKeys.SETTINGS_MENU, ConsoleColor.Gray, ConsoleColor.White);
        settingsList = new List<AvailableTool>() {
            AvailableTools.LANGUAGE_SETTINGS,
            AvailableTools.GEMINI_API_KEY_SETTINGS,
            AvailableTools.BACKUP_SETTINGS,
            AvailableTools.LOAD_SETTINGS,
            AvailableTools.RESET_FACTORY_SETTINGS,
            AvailableTools.BACK_TO_MAIN_MENU
        };
        settings = new SelectionPrompt<AvailableTool>().AddChoices(settingsList);
    }

    public override void render() {
        title.render();
        AvailableTool selected = AnsiConsole.Prompt(settings);
        if (selected == AvailableTools.MAIN_MENU) {
            AvailableTools.MAIN_MENU.switchMenu();
            return;
        }
        if (selected == AvailableTools.LANGUAGE_SETTINGS) language();
    }
}
