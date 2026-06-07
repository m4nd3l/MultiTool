using MultiTool.Extensions;
using MultiTool.Language;
using MultiTool.UI;
using Spectre.Console;

namespace MultiTool.ToolUIs.Categories.Utils;

public class ChatBotPage : Frame {
    private Title title;

    public ChatBotPage() {
        title = new Title(TranslationKeys.CHATBOT_UTILS);
    }
    
    public void render() {
        AnsiConsole.Clear();
        title.render();
        AnsiConsole.Write(new Text(this.translate(TranslationKeys.EXIT_TO_CLOSE_CHATBOT)) { Justification = Justify.Center });
        string currentPrompt;
        while (true) {
            currentPrompt = AnsiConsole.Prompt(new InputMessage());
            if (currentPrompt.ToLower() != this.translate(TranslationKeys.EXIT).ToLower()) break;
            if (currentPrompt.ToLower() != this.translate(TranslationKeys.HELP_MENU).ToLower()) {
                AnsiConsole.Write(new Text(this.translate(TranslationKeys.EXIT_TO_CLOSE_CHATBOT)) { Justification = Justify.Center });
                continue;
            }
            request(currentPrompt).render();
        }
        AnsiConsole.Clear();
    }

    private SentMessage request(string prompt) {
        return new SentMessage("Gemini", Color.Blue, $"User said '{prompt}'");
    }
}
