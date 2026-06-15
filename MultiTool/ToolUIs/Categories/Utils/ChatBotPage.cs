using Google.GenAI;
using Google.GenAI.Types;
using MultiTool.Extensions;
using MultiTool.Language;
using MultiTool.UI;
using MultiTool.Utils.Markdown;
using Spectre.Console;
using Spectre.Console.Rendering;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace MultiTool.ToolUIs.Categories.Utils;

public class ChatBotPage : Frame {
    private Title title;
    private Client? geminiClient;
    private string geminiModel = "gemini-3.5-flash";
    private string promptHeader = 
        """
        # SYSTEM INSTRUCTIONS: MultiTool CLI Assistant — Formatting System
        
        You are the AI engine for MultiTool
        
        ### RULE #1. Multiline Code Blocks
        You can use ``` to write code in multiline blocks, but remember to add a box around it, just like here:
        ```csharp
        ┌────────────────────────────────────────────────────────┐
        │public void InitializeMultiTool() {                     │
        │    if (isConfigured) return;                           │
        │    Console.WriteLine("System Ready");                  │
        │}                                                       │
        └────────────────────────────────────────────────────────┘
        ```
""";
    private Dictionary<string, string> chatHistory;

    public ChatBotPage() {
        title      = new Title(TranslationKeys.CHATBOT_UTILS, ConsoleColor.Cyan, ConsoleColor.White);
        string api = getAPIKey();
        if (!string.IsNullOrEmpty(api)) geminiClient = new Client(apiKey: api);
        chatHistory = new  Dictionary<string, string>();
    }
    
    public override void render() {
        title.render();
        AnsiConsole.Write(new Text(this.translate(TranslationKeys.EXIT_TO_CLOSE_CHATBOT)) { Justification = Justify.Center });
        AnsiConsole.WriteLine();
        string currentPrompt;
        Style loadingStyle = Style.Parse("yellow bold");
        while (true) {
            currentPrompt = AnsiConsole.Prompt(new InputMessage());
            if (currentPrompt.Equals(this.translate(TranslationKeys.EXIT), StringComparison.OrdinalIgnoreCase)) break;
            if (currentPrompt.Equals(this.translate(TranslationKeys.HELP_MENU), StringComparison.OrdinalIgnoreCase)) {
                AnsiConsole.Write(new Text(this.translate(TranslationKeys.EXIT_TO_CLOSE_CHATBOT)));
                continue;
            }
            
            SentMessage? response = null;
            bool succeded = false;
            Console.SetCursorPosition(0, Console.CursorTop);
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Dots)
                .SpinnerStyle(loadingStyle)
                .StartAsync(this.translate(TranslationKeys.LOADING_ANSWER_CHATBOT),
                            _ => {
                                var task = Task.Run(() => geminiRequest(currentPrompt));
                                task.Wait();
                                (response, succeded) = task.Result;
                                return Task.CompletedTask;
                            });
            if (succeded && response != null) {
                response.render();
                chatHistory.Add($"Prompt#{chatHistory.Count + 1}: {currentPrompt}", $"Answer#{chatHistory.Count + 1}: {response.getMessage()}");
            } else chatHistory.Add($"Prompt#{chatHistory.Count + 1}: {currentPrompt}", $"Answer#{chatHistory.Count + 1}: No answer");
            AnsiConsole.WriteLine();
        }
        AvailableTools.MAIN_MENU.switchMenu();
    }

    private async Task<(SentMessage, bool)> geminiRequest(string prompt) {
        if (geminiClient == null) {
            while (true) {
                AnsiConsole.Write(new Text(this.translate(TranslationKeys.API_KEY_NOT_FOUND_OR_VALID_CHATBOT) + "\n", Color.Red));
                string apiKey = AnsiConsole.Ask<string>(this.translate(TranslationKeys.ASK_API_KEY_CHATBOT));
                if (string.IsNullOrEmpty(apiKey)) continue;
                try { geminiClient = new Client(apiKey: apiKey); } catch { continue; }
                break;
            }
        }
        string? answer = null;
        bool succeded = true;
        try {
            string completeInput = $"{promptHeader}\n\nCHAT HISTORY: {JsonSerializer.Serialize(chatHistory)}\n\nUSER PROMPT: {prompt}"; 
            while (completeInput.Length >= 4000000 && chatHistory.Count > 0) {
                chatHistory.Remove(chatHistory.Keys.First());
                completeInput = $"{promptHeader}\n\nCHAT HISTORY: {JsonSerializer.Serialize(chatHistory)}\n\nUSER PROMPT: {prompt}";
            }
            
            GenerateContentResponse response = await geminiClient.Models.GenerateContentAsync(model: geminiModel, contents: completeInput);
            answer = response.Candidates?[0].Content?.Parts?[0].Text;
        } catch (ServerError) {
            AnsiConsole.Write(new Rule("[red]Server Busy[/]") { Justification = Justify.Left });
            AnsiConsole.MarkupLine("[yellow]Gemini models are experiencing high demand right now. Please wait a moment and try your request again.[/]");
            succeded = false;
        } catch (ClientError) {
            AnsiConsole.Write(new Rule("[red]Limit reached[/]") { Justification = Justify.Left });
            AnsiConsole.MarkupLine("[yellow]The maximum limit has been reached, please upgrade your plan or try later to continue.[/]");
            succeded = false;
        } catch (Exception ignored) { 
            AnsiConsole.Write(new Rule("[red]API Connection Error[/]") { Justification = Justify.Left });
            AnsiConsole.WriteException(ignored, ExceptionFormats.ShortenEverything);
            succeded = false;
        }
        
        if (string.IsNullOrEmpty(answer)) answer = this.translate(TranslationKeys.REQUEST_ERROR_CHATBOT);
        return (new SentMessage("Gemini", Color.Blue, convertToSpectreMarkup(answer)), succeded);
    }
    
    private List<IRenderable> convertToSpectreMarkup(string input) {
        return new MarkdownToMarkupTranslator().translateToRenderables(new MarkdownLexer().tokenize(input));
    }
}
