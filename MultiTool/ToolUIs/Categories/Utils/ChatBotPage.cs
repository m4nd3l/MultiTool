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
using Color = Spectre.Console.Color;
using File = System.IO.File;

namespace MultiTool.ToolUIs.Categories.Utils;

public class ChatBotPage : Frame {
    private Title title;
    private Client? geminiClient;
    private GenerateContentConfig config;
    private string geminiModel;
    List<string> geminiModels = new List<string> {
        "gemini-3.5-flash",
        "gemini-3.1-pro",
        "gemini-3-flash",
        "gemini-3.1-flash-lite",
        "gemini-2.5-pro",
        "gemini-2.5-flash",
        "gemini-1.5-pro",
        "gemini-1.5-flash"
    };
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
        
        ### RULE #2. Delete background-marks
        When you receive the history of the chat you will receive a dictionary in Json with
        KEY: $"Prompt#{chatHistory.Count + 1}: {currentPrompt}"
        VALUE: $"Answer#{chatHistory.Count + 1}: {response.getRawMessage()}"
        Please if the user asks to recall those messages, delete the $"Prompt#{chatHistory.Count + 1}: " or the $"Answer#{chatHistory.Count + 1}: ".
""";
    private Dictionary<string, string> chatHistory;
    private Dictionary<string, string> allChatHistory;

    public ChatBotPage() {
        title      = new Title(TranslationKeys.CHATBOT_UTILS, ConsoleColor.Cyan, ConsoleColor.White);
        string api = getAPIKey();
        if (!string.IsNullOrEmpty(api)) geminiClient = new Client(apiKey: api);
        geminiModel    = read<string>("gemini-model") ?? geminiModels[0];
        chatHistory    = new  Dictionary<string, string>();
        allChatHistory = new  Dictionary<string, string>();
        config = new GenerateContentConfig {
            SafetySettings = new List<SafetySetting> {
                new SafetySetting { Category = HarmCategory.HarmCategoryHarassment, Threshold       = HarmBlockThreshold.BlockNone },
                new SafetySetting { Category = HarmCategory.HarmCategoryHateSpeech, Threshold       = HarmBlockThreshold.BlockNone },
                new SafetySetting { Category = HarmCategory.HarmCategorySexuallyExplicit, Threshold = HarmBlockThreshold.BlockNone },
                new SafetySetting { Category = HarmCategory.HarmCategoryDangerousContent, Threshold = HarmBlockThreshold.BlockNone }
            }
        };
    }
    
    public override void render() {
        title.render();
        AnsiConsole.Write(new Text(this.translate(TranslationKeys.EXIT_TO_CLOSE_CHATBOT)) { Justification = Justify.Center });
        AnsiConsole.WriteLine();
        string currentPrompt;
        Style loadingStyle = Style.Parse("yellow bold");
        
        while (true) {
            currentPrompt = AnsiConsole.Prompt(new InputMessage());
            if (currentPrompt.StartsWith($"/{this.translate(TranslationKeys.EXIT)}", StringComparison.OrdinalIgnoreCase)) break;

            if (checkForCommands(currentPrompt)) continue;
            
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
                chatHistory.Add($"Prompt#{chatHistory.Count + 1}: {currentPrompt}", $"Answer#{chatHistory.Count + 1}: {response.getRawMessage()}");
            } else chatHistory.Add($"Prompt#{chatHistory.Count + 1}: {currentPrompt}", $"Answer#{chatHistory.Count + 1}: No answer");

            allChatHistory.Add($"Prompt#{allChatHistory.Count + 1}: {currentPrompt}", $"Answer#{allChatHistory.Count + 1}: {response?.getRawMessage() ?? "No answer"}");
            
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
            
            GenerateContentResponse response = await geminiClient.Models.GenerateContentAsync(model: geminiModel, contents: completeInput, config: config);
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
        return (new SentMessage("Gemini", Color.Blue, convertToSpectreMarkup(answer), answer), succeded);
    }

    private bool checkForCommands(string currentPrompt) {
        if (currentPrompt.StartsWith(this.translate(TranslationKeys.SAVE_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            save();
            return true;
        }
        if (currentPrompt.StartsWith(this.translate(TranslationKeys.LOAD_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            load();
            return true;
        }
        if (currentPrompt.Equals(this.translate(TranslationKeys.LIST_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            list();
            return true;
        }
        if (currentPrompt.StartsWith(this.translate(TranslationKeys.RENAME_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            rename();
            return true;
        }
        if (currentPrompt.StartsWith(this.translate(TranslationKeys.DELETE_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            delete();
            return true;
        }
        if (currentPrompt.StartsWith(this.translate(TranslationKeys.CLEAR_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            clear();
            return true;
        }
        if (currentPrompt.StartsWith(this.translate(TranslationKeys.MERGE_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            merge();
            return true;
        }
        if (currentPrompt.StartsWith(this.translate(TranslationKeys.MODELS_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            models();
            return true;
        }
        if (currentPrompt.StartsWith(this.translate(TranslationKeys.MODEL_COMMAND_CHATBOT), StringComparison.OrdinalIgnoreCase)) {
            model();
            return true;
        }
        if (currentPrompt.StartsWith($"/{this.translate(TranslationKeys.HELP_MENU)}", StringComparison.OrdinalIgnoreCase)) {
            AnsiConsole.Write(new Text(this.translate(TranslationKeys.COMMANDS_CHATBOT)));
            Console.WriteLine();
            return true;
        }
        return false;
    }

    private void list() {
        DirectoryInfo info = new DirectoryInfo(MultiToolSaving.chatHistoryDirectoryPath);
        if (!info.Exists) { AnsiConsole.WriteLine(this.translate(TranslationKeys.NO_CHAT_SAVED_CHATBOT)); return; }
        FileInfo[] files = info.GetFiles();
        foreach (FileInfo file in files) AnsiConsole.MarkupLine($"\t- [bold yellow]{file.Name}[/]");
    }

    private void save() {
        FileInfo file;
        string name;
        while (true) {
            name = sanitizeFileName(AnsiConsole.Ask<string>(this.translate(TranslationKeys.ASK_NAME_FOR_SAVING_CHATBOT)));
            file = new FileInfo(Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, name));
            if (!file.Exists) break;
            AnsiConsole.MarkupLine($"[red]{this.translate(TranslationKeys.NAME_ALREADY_USED_CHATBOT)}[/]");
        }
        
        if (file.Directory != null && !file.Directory.Exists) file.Directory.Create();
        
        file.Create().Close();
        File.WriteAllText(Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, name), JsonSerializer.Serialize(allChatHistory));
    }

    private void load() {
        (FileInfo _, string name) = askChatHistory(this.translate(TranslationKeys.ASK_SAVED_FOR_LOAD_CHATBOT));
        
        Dictionary<string, string> savedHistory = 
            JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, name))) 
            ?? new();

        allChatHistory = savedHistory;
        chatHistory = allChatHistory;
        
        clear();
        
        foreach (string key in savedHistory.Keys) {
            string markdown = savedHistory[key];
            AnsiConsole.Write(new Text(this.translate(TranslationKeys.YOU_CHATBOT) + ": ", Color.Blue));
            AnsiConsole.Write(removePromptPrefix(key));
            AnsiConsole.WriteLine();
            markdown = removeAnswerPrefix(markdown);
            new SentMessage("Gemini", Color.Blue, convertToSpectreMarkup(markdown), markdown).render();
            AnsiConsole.WriteLine();
        }
    }
    
    private void rename() {
        (FileInfo _, string name) = askChatHistory(this.translate(TranslationKeys.ASK_SAVED_FOR_RENAME_CHATBOT));
        
        FileInfo newFile;
        string newName;
        while (true) {
            newName = sanitizeFileName(AnsiConsole.Ask<string>(this.translate(TranslationKeys.ASK_NEW_NAME_FOR_RENAME_CHATBOT).Replace("[%old_name%]", name)));
            newFile = new FileInfo(Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, newName));
            if (!newFile.Exists || newName.Equals(name)) break;
            AnsiConsole.MarkupLine($"[red]{this.translate(TranslationKeys.NAME_ALREADY_USED_CHATBOT)}[/]");
        }
        
        File.Move(Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, name), 
                  Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, newName));
    }

    private void delete() {
        (FileInfo file, string name) = askChatHistory(this.translate(TranslationKeys.ASK_SAVED_FOR_DELETE_CHATBOT));
        if (!file.Exists) {
            AnsiConsole.MarkupLine($"[red]{this.translate(TranslationKeys.NO_CHAT_SAVED_WITH_NAME_CHATBOT) + name}[/]");
            return;
        }
        File.Delete(Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, name));
    }

    private void merge() {
        FileInfo mergedFile;
        string mergedName;
        bool addThisChat, deleteMergedChats;
        
        (List<FileInfo> files, List<string> _) = askMultipleChatHistories(this.translate(TranslationKeys.ASK_SAVED_FOR_MERGE_CHATBOT));
        while (true) {
            mergedName = sanitizeFileName(AnsiConsole.Ask<string>(this.translate(TranslationKeys.ASK_NAME_FOR_SAVING_CHATBOT)));
            mergedFile = new FileInfo(Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, mergedName));
            if (!mergedFile.Exists) break;
            AnsiConsole.MarkupLine($"[red]{this.translate(TranslationKeys.NAME_ALREADY_USED_CHATBOT)}[/]");
        }
        
        addThisChat       = AnsiConsole.Confirm($"[yellow]{this.translate(TranslationKeys.ASK_ADD_THIS_CHAT_CHATBOT)}[/]");
        deleteMergedChats = AnsiConsole.Confirm($"[yellow]{this.translate(TranslationKeys.ASK_DELETE_SELECTED_CHATS_CHATBOT)}[/]");
        
        List<Dictionary<string, string>> chatHistories = 
            files.Select(file => JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(file.FullName)) 
                                                                              ?? new Dictionary<string, string>()).ToList();
        if (addThisChat) chatHistories.Add(allChatHistory);

        Dictionary<string, string> final = new Dictionary<string, string>();
        chatHistories.ForEach(history => history.Keys.ToList().ForEach(key => final[key] = history[key]));
        
        if (mergedFile.Directory != null && !mergedFile.Directory.Exists) mergedFile.Directory.Create();
        
        mergedFile.Create().Close();
        File.WriteAllText(Path.Combine(MultiToolSaving.chatHistoryDirectoryPath, mergedName), JsonSerializer.Serialize(final));

        if (!deleteMergedChats) return;
        foreach (FileInfo file in files) file.Delete();
    }

    private void model() {
        AnsiConsole.MarkupLine($"[yellow]{this.translate(TranslationKeys.SHOW_MODEL_CHATBOT)}[/][bold blue]{geminiModel}[/]");
    }
    
    private void models() {
        model();
        List<string> choices = geminiModels;
        choices.Remove(geminiModel);
        string current = $"{geminiModel} -> {this.translate(TranslationKeys.CURRENT_CHATBOT)}";
        choices.Add(current);
        geminiModel = AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(geminiModels).Title(this.translate(TranslationKeys.ASK_MODEL_CHATBOT)));
        save("gemini-model",  geminiModel);
    }

    private void clear() {
        AnsiConsole.Clear();
        allChatHistory = new Dictionary<string, string>();
        chatHistory = new Dictionary<string, string>();
        title.render();
        AnsiConsole.Write(new Text(this.translate(TranslationKeys.EXIT_TO_CLOSE_CHATBOT)) { Justification = Justify.Center });
        AnsiConsole.WriteLine();
    }

    private List<IRenderable> convertToSpectreMarkup(string input) {
        return new MarkdownToMarkupTranslator().translateToRenderables(new MarkdownLexer().tokenize(input));
    }

    public string sanitizeFileName(string originalName) {
        if (string.IsNullOrEmpty(originalName)) return string.Empty;
        if (originalName.StartsWith(' ')) originalName = originalName.Substring(1);
        string cleanName = originalName.Replace(" ", "_");
        char[] invalidCharacters = Path.GetInvalidFileNameChars();

        for (int i = 0; i < invalidCharacters.Length; i++) {
            char invalidCharacter = invalidCharacters[i];
            if (cleanName.Contains(invalidCharacter)) cleanName = cleanName.Replace(invalidCharacter.ToString(), string.Empty);
        }
        
        return cleanName;
    }
    
    public string removePromptPrefix(string originalText) {
        if (string.IsNullOrEmpty(originalText)) return string.Empty;
        return Regex.Replace(originalText, @"^Prompt#\d+:\s*", string.Empty);
    }
    
    public string removeAnswerPrefix(string originalText) {
        if (string.IsNullOrEmpty(originalText)) return string.Empty;
        return Regex.Replace(originalText, @"Answer#\d+:\s*", string.Empty);
    }

    private List<FileInfo> getChatHistory() {
        DirectoryInfo info = new DirectoryInfo(MultiToolSaving.chatHistoryDirectoryPath);
        if (!info.Exists) { AnsiConsole.WriteLine(this.translate(TranslationKeys.NO_CHAT_SAVED_CHATBOT)); return new (); }
        return new List<FileInfo>(info.GetFiles());
    }

    private (FileInfo, string) askChatHistory(string? askTitle = null) {
        FileInfo selected = 
            AnsiConsole.Prompt(new SelectionPrompt<FileInfo>()
                                   .AddChoices(getChatHistory())
                                   .UseConverter(file => file.Name)
                                   .Title(askTitle ?? this.translate(TranslationKeys.ASK_SAVED_CHATBOT)));
        return (selected, selected.Name);
    }
    
    private (List<FileInfo>, List<string>) askMultipleChatHistories(string? askTitle = null) {
        List<FileInfo> selected = 
            AnsiConsole.Prompt(new MultiSelectionPrompt<FileInfo>()
                                   .AddChoices(getChatHistory())
                                   .UseConverter(file => file.Name)
                                   .Title(askTitle ?? this.translate(TranslationKeys.ASK_MULTIPLE_SAVED_CHATBOT)));
        return (selected, selected.Select(file => file.Name).ToList());
    }
}
