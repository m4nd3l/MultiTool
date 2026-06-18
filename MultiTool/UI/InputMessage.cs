using MultiTool.Extensions;
using MultiTool.Language;
using Spectre.Console;
using Color = Spectre.Console.Color;

namespace MultiTool.UI;

public class InputMessage : IPrompt<string> {
    public Task<string> ShowAsync(IAnsiConsole console, CancellationToken cancellationToken) => throw new NotImplementedException();

    public string Show(IAnsiConsole console) {
        bool first = true, warned = false;
        string? input = "";
    
        AnsiConsole.Write(new Text(this.translate(TranslationKeys.YOU_CHATBOT) + ": ", Color.Blue));
        int promptCursorTop = Console.CursorTop;
        int promptCursorLeft = Console.CursorLeft;

        while (string.IsNullOrEmpty(input)) {
            int currentBufferTop = Console.CursorTop;

            if (!first && !warned) {
                warned = true;
                int targetWarningTop = (promptCursorTop < Console.BufferHeight - 1) ? promptCursorTop + 1 : currentBufferTop;
            
                if (targetWarningTop >= 0 && targetWarningTop < Console.BufferHeight) {
                    Console.SetCursorPosition(0, targetWarningTop);
                    AnsiConsole.Write(new Text(this.translate(TranslationKeys.NULL_OR_EMPTY_PROMPT_CHATBOT), Color.Red));
                }
            }

            if (promptCursorTop >= 0 && promptCursorTop < Console.BufferHeight) Console.SetCursorPosition(promptCursorLeft, promptCursorTop);
            else Console.SetCursorPosition(promptCursorLeft, currentBufferTop);
        
            input = Console.ReadLine();
            first = false;
        }
    
        if (warned) {
            int currentBufferTop = Console.CursorTop;
            int targetWarningTop = (promptCursorTop < Console.BufferHeight - 1) ? promptCursorTop + 1 : currentBufferTop;
        
            if (targetWarningTop >= 0 && targetWarningTop < Console.BufferHeight) {
                Console.SetCursorPosition(0, targetWarningTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, targetWarningTop);
            }
        }

        return input;
    }
}
