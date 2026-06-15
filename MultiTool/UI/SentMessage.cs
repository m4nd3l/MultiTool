using Spectre.Console;
using Spectre.Console.Rendering;
using System.Text.RegularExpressions;

namespace MultiTool.UI;

public class SentMessage {
    private string sender;
    private List<IRenderable> message;
    private Color senderColor, messageColor;

    public SentMessage(string sender, List<IRenderable> message) : this(sender, Color.Gray, message) {  }
    public SentMessage(string sender, ConsoleColor senderColor, List<IRenderable> message) : this(sender, Color.FromConsoleColor(senderColor), message, Color.Gray) {  }
    public SentMessage(string sender, ConsoleColor senderColor, List<IRenderable> message, ConsoleColor messageColor)
        : this(sender, Color.FromConsoleColor(senderColor), message, Color.FromConsoleColor(messageColor)) {  }
    public SentMessage(string sender, Color senderColor, List<IRenderable> message) : this(sender, senderColor, message, Color.Gray) {  }
    public SentMessage(string sender, Color senderColor, List<IRenderable> message, Color messageColor) {
        this.sender       = sender;
        this.message      = message;
        this.senderColor  = senderColor;
        this.messageColor = messageColor;
    }

    public void render() {
        AnsiConsole.Write(new Text(sender + ": ", senderColor));
        
        foreach (IRenderable element in message) AnsiConsole.Write(element);
        AnsiConsole.WriteLine();
    }
    
    public string getSender() => sender;
    public List<IRenderable> getMessage() => message;
}
