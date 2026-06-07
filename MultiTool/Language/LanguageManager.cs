using System.Text.Json;

namespace MultiTool.Language;

public class LanguageManager {
    private static LanguageData? language;

    public static void init() {
        language = JsonSerializer.Deserialize<LanguageData>(DefaultLanguages.ENGLISH, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public static void changeLanguage(string json) {
        language = JsonSerializer.Deserialize<LanguageData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
    
    public static string getTranslation(Key key) => language == null ? "Unknown" : string.IsNullOrEmpty(language?.get(key)) ? "Unknown" : language.get(key);
}
