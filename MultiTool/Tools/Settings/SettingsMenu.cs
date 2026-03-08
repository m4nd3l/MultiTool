using MultiTool.Tools.Utils;
using MultiTool.UI.Elements.Basic;
using MultiTool.UI.Elements.Basic.Color;
using MultiTool.UI.Elements.Basic.Settings;
using MultiTool.UI.Elements.Menu;
using MultiTool.UI.Elements.TextElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTool.Tools.Settings;
public class SettingsMenu : Frame {
    private List<string> titleText = new List<string>() {
            "",
            "  ██████  ▓█████▄▄ ▄█████▓▄▄▄█████▓  ██▓ ███▄    █   ▄████   ██████ ",
            "▒██    ▒  ▓█   ▀▓   ██▒ ▓▒▓  ██▒ ▓ ▒▓██▒ ██ ▀█   █  ██▒ ▀█▒▒██    ▒ ",
            "░ ▓██▄    ▒████ ▒  ▓██░ ▒░▒ ▓██░ ▒ ░▒██▒▓██  ▀█ ██▒▒██░▄▄▄░░ ▓██▄   ",
            "  ▒   ██▒ ▒▓█  ▄░  ▓██▓ ░ ░ ▓██▓ ░  ░██░▓██▒  ▐▌██▒░▓█  ██▓  ▒   ██▒",
            "▒██████▒▒ ░▒████▒  ▒██▒ ░   ▒██▒ ░  ░██░▒██░   ▓██░░▒▓███▀▒ ▒█████▒▒ ",
            "▒ ▒▓▒ ▒ ░ ░░ ▒░ ░  ▒ ░░     ▒ ░░    ░▓  ░ ▒░   ▒ ▒  ░▒   ▒ ▒ ▒▓▒ ▒ ░",
            "░ ░▒  ░ ░  ░ ░  ░    ░        ░      ▒ ░░ ░░   ░ ▒░  ░   ░ ░ ░▒  ░ ░",
            "░  ░  ░      ░     ░        ░        ▒ ░   ░   ░ ░ ░ ░   ░ ░  ░  ░  ",
            "      ░      ░  ░                    ░           ░       ░       ░  ",
    };

    private List<MenuItem> mainMenuItems = new List<MenuItem>() {
            new PageMenuItem<ChatBotSettings>($"ChatBot Configuration"), // 0
            new MenuItem($"Reset"),                 // 1
            new ToMainPageMenuItem(),               // 2
        };

    private Title title;
    private Menu menu;

    public override void initialize() {
        GlobalSettings.enableEmojis();
        title = new Title(titleText, new ColorGradient(new Color(Colors.Red), new Color(Colors.White)));
        menu = new Menu(title, mainMenuItems, true);
    }
    public override void run() {
        bool exit = false;
        while (!exit) {
            int selectedIndex = menu.run();
            if (selectedIndex == 1) {
                save("indexai", 0);
                saveAPIKey("None");
            } else if (selectedIndex == 2)
                exit = true;
        }
    }
}