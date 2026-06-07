using Spectre.Console;

namespace MultiTool.UI;

public class SentMessage {
    private string sender, message;
    private Color senderColor, messageColor;

    public SentMessage(string sender, string message) : this(sender, Color.White, message) {  }
    public SentMessage(string sender, ConsoleColor senderColor, string message) : this(sender, Color.FromConsoleColor(senderColor), message, Color.White) {  }
    public SentMessage(string sender, ConsoleColor senderColor, string message, ConsoleColor messageColor)
        : this(sender, Color.FromConsoleColor(senderColor), message, Color.FromConsoleColor(messageColor)) {  }
    public SentMessage(string sender, Color senderColor, string message) : this(sender, senderColor, message, Color.White) {  }
    public SentMessage(string sender, Color senderColor, string message, Color messageColor) {
        this.sender       = sender;
        this.message      = message;
        this.senderColor  = senderColor;
        this.messageColor = messageColor;
    }

    public void render() {
        AnsiConsole.Write(new Text(sender + ": ", senderColor));
        AnsiConsole.Write(new Text(message + "\n", messageColor));
    }
}
