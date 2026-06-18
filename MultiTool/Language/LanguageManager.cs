using System.Runtime.CompilerServices;
using System.Text.Json;

namespace MultiTool.Language;

public class LanguageManager {
    private static string currentKey;
    private static Dictionary<string, LanguageData> languages;

    public static void init() {
        languages = new Dictionary<string, LanguageData>();
        
        LanguageData? ENGLISH = JsonSerializer.Deserialize<LanguageData>(DefaultLanguages.ENGLISH, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (ENGLISH != null) languages.Add(ENGLISH.name, ENGLISH);
        
        DirectoryInfo languageDirectory = new DirectoryInfo(MultiToolSaving.languagesDirectoryPath);
        if (languageDirectory.Exists) {
            FileInfo[] files = languageDirectory.GetFiles();
            foreach (FileInfo file in files) {
                LanguageData? languageData 
                    = JsonSerializer.Deserialize<LanguageData>(File.ReadAllText(file.FullName), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (languageData != null) languages.Add(languageData.name, languageData);
            }
        }
    }

    public static void changeLanguageKey(string newLanguageKey) { currentKey = newLanguageKey; } 
    
    public static void changeLanguage(string json) {
        LanguageData? languageData = JsonSerializer.Deserialize<LanguageData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (languageData == null) return;
        languages.TryAdd(languageData.name, languageData);
        currentKey = languageData.name;
    }

    public static string getTranslation(Key key) => languages.ContainsKey(currentKey) ? languages[currentKey].get(key) : "Unknown";
}
