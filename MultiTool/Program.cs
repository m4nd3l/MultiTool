using System.ComponentModel;
using MultiTool.UI.Elements.Menu;
using MultiTool.UI.Elements.Basic.Color;
using MultiTool.UI.Elements.Basic.Settings;
using MultiTool.UI.Elements.TextElements;
using MultiTool.Tools;
using MultiTool.Utils;

public class Program {
    public static void Main(string[] args) {
        MultiToolSettings.initialize();
        MainMenu mainMenu = new MainMenu();
        mainMenu.initialize();
        mainMenu.run();
    }
}