using MultiTool.Tools.Utils;
using MultiTool.UI.Elements.Basic;
using MultiTool.UI.Elements.Basic.Color;
using MultiTool.UI.Elements.Basic.Settings;
using MultiTool.UI.Elements.Menu;
using MultiTool.UI.Elements.TextElements;
using Windows.Storage;
using Windows.Security.Credentials;

namespace MultiTool.Tools.Settings;
public class ChatBotSettings : Frame {
    private List<string> titleText = new List<string>() {
            "",
            " ▄████▄   ██░ ██  ▄▄▄     ▄▄▄█████▓ ▄▄▄▄    ▒█████  ▄▄▄█████▓",
            "▒██▀ ▀█  ▓██░ ██▒▒████▄   ▓  ██▒ ▓▒▓█████▄ ▒██▒  ██▒▓  ██▒ ▓▒",
            "▒▓█    ▄ ▒██▀▀██░▒██  ▀█▄ ▒ ▓██░ ▒░▒██▒ ▄██▒██░  ██▒▒ ▓██░ ▒░",
            "▒▓▓▄ ▄██▒░▓█ ░██ ░██▄▄▄▄██░ ▓██▓ ░ ▒██░█▀  ▒██   ██░░ ▓██▓ ░ ",
            "▒ ▓███▀ ░░▓█▒░██▓ ▓█   ▓██▒ ▒██▒ ░ ░▓█  ▀█▓░ ████▓▒░  ▒██▒ ░ ",
            "░ ░▒ ▒  ░ ▒ ░░▒░▒ ▒▒   ▓▒█░ ▒ ░░   ░▒▓███▀▒░ ▒░▒░▒░   ▒ ░░   ",
            "  ░  ▒    ▒ ░▒░ ░  ▒   ▒▒ ░   ░    ▒░▒   ░   ░ ▒ ▒░     ░    ",
            "░         ░  ░░ ░  ░   ▒    ░       ░    ░ ░ ░ ░ ▒    ░      ",
            "░ ░       ░  ░  ░      ░  ░         ░          ░ ░           ",
            "░                                        ░                   ",
    };

    private List<MenuItem> mainMenuItems = new List<MenuItem>() {
            new MenuItem($"ChatGPT"),     // 0
            new MenuItem($"Gemini"),      // 1
            new MenuItem($"Deepseek"),    // 2
            new MenuItem($"Set API Key"), // 3
            new ToMainPageMenuItem(),     // 4
        };

    private Title title;
    private Menu menu;
    private Text apiText;

    private string localAPIKey = "None";
    private int localAIIndex = 0;

    public override void initialize() {
        GlobalSettings.enableEmojis();
        localAPIKey = getAPIKey();
        
        localAIIndex = read<int>("indexai") == null ? 0 : read<int>("indexai");
        title = new Title(titleText, new ColorGradient(new Color(Colors.Red), new Color(Colors.White)));
        menu = new Menu(title, mainMenuItems, true, selected: localAIIndex);
        apiText = new Text($"Current API Key: {localAPIKey}");
    }
    public override void run() {
        bool exit = false;
        while (!exit) {
            Console.WriteLine("helloss");
            exit = check(menu.run(() => { apiText.display(); }, localAIIndex));
        }
    }

    public void saveEverything() {
        if (localAIIndex != -1)    save("indexai", localAIIndex);
        if (localAPIKey != "None") saveAPIKey(localAPIKey);
    }

    private bool check(int selectedIndex) {
        if (selectedIndex == 4)
            return true;
        if (selectedIndex == 3) {
            new Text("Enter new API Key:").display(true, false);
            string newKey = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newKey)) {
                new Text("API Key cannot be empty. Please enter a valid API Key:").display(true, false);
                newKey = Console.ReadLine();
            }
            localAPIKey = newKey;
            apiText = new Text($"Current API Key: {localAPIKey}");
        } else { 
            localAIIndex = selectedIndex;
            menu.setSelected(selectedIndex);
        }
        saveEverything();
        return false;
    }
}
