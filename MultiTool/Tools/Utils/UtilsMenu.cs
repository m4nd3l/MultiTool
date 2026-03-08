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

namespace MultiTool.Tools.Utils;
public class UtilsMenu : Frame {
    private List<string> titleText = new List<string>() {
            "",
            " █    ██  ▄▄▄█████▓  ██▓  ██▓       ██████ ",
            " ██  ▓██▒ ▓  ██▒ ▓▒ ▓██▒ ▓██▒     ▒██    ▒ ",
            "▓██  ▒██░ ▒ ▓██░ ▒░ ▒██▒ ▒██░     ░ ▓██▄   ",
            "▓▓█  ░██░ ░ ▓██▓ ░  ░██░ ▒██░       ▒   ██▒",
            "▒▒█████▓    ▒██▒ ░  ░██░ ░██████▒ ▒██████▒▒",
            "░▒▓▒ ▒ ▒    ▒ ░░    ░▓  ░  ▒░▓  ░ ▒ ▒▓▒ ▒ ░",
            "░░▒░ ░ ░      ░      ▒ ░░  ░ ▒  ░ ░ ░▒  ░ ░",
            " ░░░ ░ ░    ░        ▒ ░   ░ ░   ░   ░  ░  ",
            "   ░                 ░       ░  ░      ░  ",
                                       
    };

    private List<MenuItem> mainMenuItems = new List<MenuItem>() {
            new MenuItem($"ChatBot"),             // 0
            new MenuItem($"Password Generator"),  // 1
            new MenuItem($"Mock Data Generator"), // 2
            new MenuItem($"Epoch & Timezone"),    // 3
            new ToMainPageMenuItem(),             // 4
        };

    private Title title;
    private Menu menu;

    public override void initialize() {
        GlobalSettings.enableEmojis();
        title = new Title(titleText, new ColorGradient(new Color(Colors.DarkGray), new Color(Colors.White)));
        menu = new Menu(title, mainMenuItems, true);
    }

    public override void run() {
        int selectedIndex = menu.run();
        onClickMenu(selectedIndex);
    }

    private void onClickMenu(int index) {
        const int chatbotIndex = 0,
                  passwordGeneratorIndex = 1,
                  mockDataGeneratorIndex = 2,
                  epochAndTimezoneIndex = 3,
                  backIndex = 4;
        switch (index) {
            case chatbotIndex:
                Console.WriteLine(index);
                //switchToPage<UtilsMenu>();
                break;
            case passwordGeneratorIndex:
                Console.WriteLine(index);
                //switchToPage<UtilsMenu>();
                break;
            case mockDataGeneratorIndex:
                Console.WriteLine(index);
                //switchToPage<UtilsMenu>();
                break;
            case epochAndTimezoneIndex:
                Console.WriteLine(index);
                //switchToPage<UtilsMenu>();
                break;
            case backIndex:
                switchToPage<MainMenu>();
                break;
            default:
                Console.WriteLine("Pressed unknown button...");
                run();
                break;
        }
    }

    private void switchToPage<T>() where T : Frame, new() {
        T page = new T();
        page.initialize();
        page.run();
    }
}
