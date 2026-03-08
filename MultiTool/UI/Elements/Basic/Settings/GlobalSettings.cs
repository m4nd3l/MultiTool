using MultiTool.UI.Elements.Basic.Color;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTool.UI.Elements.Basic.Settings;
public class GlobalSettings {
    private static UISettings _settings = new UISettings(
            new TextColor(ConsoleColor.Red, ConsoleColor.Black),
            new TextColor(ConsoleColor.White, ConsoleColor.Black),
            new TextColor(ConsoleColor.Black, ConsoleColor.White),
            new TextColor(ConsoleColor.White, ConsoleColor.Green),
            new TextColor(ConsoleColor.White, ConsoleColor.Red)
        );

    public static void enableEmojis() {
        Console.OutputEncoding = Encoding.UTF8;
    }

    public static void setSettings(UISettings settings) {
        _settings = settings;
    }
    public static UISettings getSettings() {
        return _settings;
    }
}

