using MultiTool.Tools.Settings;
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

namespace MultiTool.Tools;
public class MainMenu : Frame {
    private List<string> titleText = new List<string>() {
            "",
            " ███▄ ▄███▓  █    ██   ██▓    ▄▄▄█████▓  ██▓ ▄▄▄█████▓ ▒█████    ▒█████    ██▓     ",
            "▓██▒███ ██▒  ██  ▓██▒ ▓██▒    ▓  ██▒ ▓▒ ▓██▒▓   ██▒  ▓▒▒██▒  ██▒ ▒██▒  ██▒ ▓██▒     ",
            "▓██  █ ▓██░ ▓██  ▒██░ ▒██░    ▒ ▓██░ ▒░ ▒██▒▒  ▓██░  ▒░▒██░  ██▒ ▒██░  ██▒ ▒██░     ",
            "▒██    ▒██  ▓▓█  ░██░ ▒██░    ░ ▓██▓ ░  ░██░░  ▓██▓  ░ ▒██   ██░ ▒██   ██░ ▒██░     ",
            "▒██▒   ░██▒ ▒▒█████▓  ░██████▒  ▒██▒ ░  ░██░   ▒██▒  ░ ░ ████▓▒░ ░ ████▓▒░ ░██████▒ ",
            "░ ▒░   ░   ░░▒▓▒ ▒ ▒  ░ ▒░▓    ░▒ ░░    ░▓     ▒ ░░    ░ ▒░▒░▒░  ░ ▒░▒░▒░  ░ ▒░▓  ░ ",
            "░  ░       ░░░▒░ ░ ░  ░ ░ ▒    ░  ░     ▒ ░     ░       ░ ▒ ▒░    ░ ▒ ▒░  ░ ░ ▒  ░ ",
            "░      ░    ░░░ ░ ░    ░ ░     ░       ▒  ░   ░       ░ ░ ░ ▒   ░ ░ ░ ▒     ░ ░    ",
            "       ░      ░          ░    ░        ░               ░ ░       ░ ░       ░  ░ ",
    };

    private List<MenuItem> mainMenuItems = new List<MenuItem>() {
            new PageMenuItem<UtilsMenu>($"🔨 UTILS"), // 0
            new MenuItem($"💻 SYSTEM"),      // 1
            new MenuItem($"💾 STORAGE"),     // 2
            new MenuItem($"🌐 NETWORK"),     // 3
            new MenuItem($"💔 DIAGNOSTICS"), // 4
            new MenuItem($"🚨 EMERGENCY"),   // 5
            new MenuItem($"❓ HELP", spaceModifier: -1),        // 6
            new PageMenuItem<SettingsMenu>($"⚙️ SETTINGS"),    // 7
            new MenuItem($"🚪 EXIT"),        // 8
        };

    private Title title;
    private Menu menu;

    public override void initialize() {
        GlobalSettings.enableEmojis();
        title = new Title(titleText, new ColorGradient(new Color(Colors.Red), new Color(Colors.White)));
        menu = new Menu(title, mainMenuItems, true, true);
    }
    public override void run() {
        menu.run();
    }
}
