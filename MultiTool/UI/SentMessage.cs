using Spectre.Console;
using Spectre.Console.Rendering;
using System.Text.RegularExpressions;
using Color = Spectre.Console.Color;

namespace MultiTool.UI;

public class SentMessage {
    private string sender, rawMessage;
    private List<IRenderable> message;
    private Color senderColor;
    
    public SentMessage(string sender, ConsoleColor senderColor, List<IRenderable> message, string rawMessage) 
        : this(sender, Color.FromConsoleColor(senderColor), message, rawMessage) {  }
    public SentMessage(string sender, Color senderColor, List<IRenderable> message, string rawMessage) {
        this.sender       = sender;
        this.senderColor  = senderColor;
        this.message      = message;
        this.rawMessage = rawMessage;
    }

    public void render() {
        AnsiConsole.Write(new Text(sender + ": ", senderColor));
        
        foreach (IRenderable element in message) AnsiConsole.Write(element);
        AnsiConsole.WriteLine();
    }
    
    public string getSender() => sender;
    public List<IRenderable> getMessage() => message;
    public string getRawMessage() => rawMessage;
}
