using MultiTool.Language;
using System.Text.Json;

namespace MultiTool;

public class MultiToolSaving {
    private static readonly string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\MultiTool";
    public static readonly string filePath = Path.Combine(path, "settings");
    public static readonly string chatHistoryDirectoryPath = Path.Combine(path, "chatbot_history");
    public static readonly string languagesDirectoryPath = Path.Combine(path, "languages");
    private static Dictionary<string, object> settings = new Dictionary<string, object>();

    public static void init() {
        if (File.Exists(filePath)) {
            settings = JsonSerializer.Deserialize<Dictionary<string, object>>(File.ReadAllText(filePath)) ?? new();
            return;
        }
        settings = new();
        string? directory = Path.GetDirectoryName(filePath);
        string? chatHistoryDirectory = Path.GetDirectoryName(chatHistoryDirectoryPath);
        string? languagesDirectory = Path.GetDirectoryName(languagesDirectoryPath);
        if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);
        if (!string.IsNullOrEmpty(chatHistoryDirectory)) Directory.CreateDirectory(chatHistoryDirectory);
        if (!string.IsNullOrEmpty(languagesDirectory)) Directory.CreateDirectory(languagesDirectory);
        if (File.Exists(filePath)) return;
        File.Create(filePath).Close();
        File.WriteAllText(filePath, "{}");
    }

    public static void saveSetting(string key, object value) {
        settings[key] = value;
        File.WriteAllText(filePath, JsonSerializer.Serialize(settings));
    }

    public static T? getSetting<T>(string key) {
        if (settings.TryGetValue(key, out var value))
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(value));
        return default;
    }

    public static Dictionary<string, object> getSettings() => settings;
    public static void setSettings(Dictionary<string, object> newSettings) { settings = newSettings; }
}
