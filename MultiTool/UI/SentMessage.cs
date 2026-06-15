using Spectre.Console;
using System.Text.RegularExpressions;

namespace MultiTool.UI;

public class SentMessage {
    private string sender, message;
    private Color senderColor, messageColor;

    public SentMessage(string sender, string message) : this(sender, Color.Gray, message) {  }
    public SentMessage(string sender, ConsoleColor senderColor, string message) : this(sender, Color.FromConsoleColor(senderColor), message, Color.Gray) {  }
    public SentMessage(string sender, ConsoleColor senderColor, string message, ConsoleColor messageColor)
        : this(sender, Color.FromConsoleColor(senderColor), message, Color.FromConsoleColor(messageColor)) {  }
    public SentMessage(string sender, Color senderColor, string message) : this(sender, senderColor, message, Color.Gray) {  }
    public SentMessage(string sender, Color senderColor, string message, Color messageColor) {
        this.sender       = sender;
        this.message      = message;
        this.senderColor  = senderColor;
        this.messageColor = messageColor;
    }

    public void render() {
        AnsiConsole.Write(new Text(sender + ": ", senderColor));
        AnsiConsole.Write(new Markup(message, new Style(messageColor)));
    }
    
    public string getSender() => sender;
    public string getMessage() => message;
}
