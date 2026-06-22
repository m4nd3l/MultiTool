using MultiTool.Extensions;
using MultiTool.Language;
using MultiTool.UI;
using Spectre.Console;
using System.Text.Json;
using Keys = MultiTool.Language.Keys;

namespace MultiTool.ToolUIs.Categories;

public class SettingsPage : Frame {
    private Title title;
    private SelectionPrompt<AvailableTool> settingsMenu;
    private List<AvailableTool> settingsList;

    public SettingsPage() {
        title = new Title(Keys.SETTINGS_MENU, ConsoleColor.Gray, ConsoleColor.White);
        settingsList = new List<AvailableTool>() {
            AvailableTools.LANGUAGE_SETTINGS,
            AvailableTools.GEMINI_API_KEY_SETTINGS,
            AvailableTools.BACKUP_SETTINGS,
            AvailableTools.LOAD_SETTINGS,
            AvailableTools.RESET_FACTORY_SETTINGS,
            AvailableTools.BACK_TO_MAIN_MENU
        };
        settingsMenu = new SelectionPrompt<AvailableTool>().AddChoices(settingsList);
    }

    public override void render() {
        while (true) {
            title.render();
            AvailableTool selected = AnsiConsole.Prompt(settingsMenu);
            if (selected == AvailableTools.MAIN_MENU) break;
            if (selected == AvailableTools.LANGUAGE_SETTINGS) language();
            if (selected == AvailableTools.GEMINI_API_KEY_SETTINGS) api();
            if (selected == AvailableTools.BACKUP_SETTINGS) backup();
            if (selected == AvailableTools.LOAD_SETTINGS) load();
            if (selected == AvailableTools.RESET_FACTORY_SETTINGS) reset();
            clear();
        }
        AvailableTools.MAIN_MENU.switchMenu();
    }

    private void language() {
        LanguageManager.init();
        List<string> languages = LanguageManager.getLanguages();
        languages.Remove(LanguageManager.getLanguage());
        string currentLanguage = $"{LanguageManager.getLanguage()} -> {this.translate(Keys.CURRENT_CHATBOT)}";
        languages.Add(currentLanguage);
        string selected = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(languages));
        if (selected != currentLanguage) LanguageManager.changeLanguageKey(selected);
    }

    private void api()  {
        string? apiKey = getAPIKey();
        if (apiKey != null)
            AnsiConsole.WriteLine(this.translate(Keys.CURRENT_API_KEY_SETTINGS) + apiKey);
        while (true) {
            string newAPIKey = AnsiConsole.Ask<string>(this.translate(Keys.ASK_API_KEY_CHATBOT));
            if (string.IsNullOrEmpty(newAPIKey)) break;
            try { saveAPIKey(newAPIKey); }
            catch { continue; }
            break;
        }
    }

    private void backup() {
        string location = promptForNewFilePath();
        byte[] settings = JsonSerializer.SerializeToUtf8Bytes(MultiToolSaving.getSettings());
        
        string? directoryPath = Path.GetDirectoryName(location);
        if (directoryPath != null) Directory.CreateDirectory(directoryPath);
        
        File.WriteAllBytes(location, settings);
    }
    
    private void load() {
        string location = promptForFile();
        if (!File.Exists(location)) return;
        Dictionary<string, object> settings 
            = JsonSerializer.Deserialize<Dictionary<string, object>>(File.ReadAllBytes(location)) ?? MultiToolSaving.getSettings();
        MultiToolSaving.setSettings(settings);
        LanguageManager.init();
    }

    private void reset() {
        File.Delete(MultiToolSaving.filePath);
        MultiToolSaving.init();
        LanguageManager.init();
    }
}
