using MultiTool.Extensions;
using MultiTool.Language;
using MultiTool.UI;
using MultiTool.UI.FiggleFont;
using Spectre.Console;
using Keys = MultiTool.Language.Keys;

namespace MultiTool.ToolUIs.Categories.Utils;

public class TextConverterPage : Frame {
    private Title title;

    public TextConverterPage() {
        title = new Title(Keys.TEXT_CONVERTER_UTILS, ConsoleColor.Cyan, ConsoleColor.White);
    }

    public override void render() {
        bool stopped = false;
        while (!stopped) {
            AnsiConsole.Clear();
            title.render();
            string input;
            while (true) {
                input = AnsiConsole.Ask<string>($"[blue]{this.translate(Keys.ENTER_TEXT)}[/]");
                if (!string.IsNullOrEmpty(input)) break;
                stopped = true;
            }
            
            if (stopped) continue;
        
            string conversionType = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"[yellow]{this.translate(Keys.ASK_ACTION)}[/]")
                    .AddChoices(new List<string> { 
                        this.translate(Keys.UPPERCASE), 
                        this.translate(Keys.LOWERCASE),
                        this.translate(Keys.BLOODY_FONT),
                        this.translate(Keys.BASE64_ENCODE),
                        this.translate(Keys.BASE64_DECODE)
                    })
            );

            string result = string.Empty;
            if (conversionType.Equals(this.translate(Keys.UPPERCASE))) result          = input.ToUpper();
            else if (conversionType.Equals(this.translate(Keys.LOWERCASE))) result     = input.ToLower();
            else if (conversionType.Equals(this.translate(Keys.BLOODY_FONT))) result   = BloodyFont.BLOODY.Render(input);
            else if (conversionType.Equals(this.translate(Keys.BASE64_ENCODE))) result = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
            else if (conversionType.Equals(this.translate(Keys.BASE64_DECODE))) {
                try { result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input)); }
                catch { result = this.translate(Keys.INVALID_BASE64_STRING); }
            }

            AnsiConsole.Write(new Rule("[green]Result[/]") { Justification = Justify.Left });
            AnsiConsole.MarkupLine($"[bold white]{result}[/]\n");
            AnsiConsole.WriteLine(this.translate(Keys.PRESS_ENTER_TO_CONTINUE));
            Console.ReadKey(true);
        }
        
        AnsiConsole.WriteLine(this.translate(Keys.PRESS_ENTER_TO_CONTINUE));
        Console.ReadKey(true);
        AvailableTools.MAIN_MENU.switchMenu();
    }
}
