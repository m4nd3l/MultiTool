using MultiTool.Extensions;
using MultiTool.Language;
using Spectre.Console;

namespace MultiTool.UI;

public class InputMessage : IPrompt<string> {
    public Task<string> ShowAsync(IAnsiConsole console, CancellationToken cancellationToken) => throw new NotImplementedException();
    public string Show(IAnsiConsole console) {
        bool first = true;
        string? input = Console.ReadLine();
        while (string.IsNullOrEmpty(input) || first) {
            if (!first) AnsiConsole.Write(new Text(this.translate(TranslationKeys.NULL_OR_EMPTY_PROMPT_CHATBOT) + "\n", Color.Red));
            first = false;
            AnsiConsole.Write(new Text(this.translate(TranslationKeys.YOU_CHATBOT) + ": ", Color.Blue));
            input = Console.ReadLine();
        }
        return input;
    }
}
