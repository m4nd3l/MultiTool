using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiTool.Utils;
public class MultiToolSettings {
    public static string filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\MultiTool\\settings.txt";
    private static Dictionary<string, object> settings = new Dictionary<string, object>();

    public static void initialize() {
        if (File.Exists(filePath))
            settings = JsonSerializer.Deserialize<Dictionary<string, object>>(File.ReadAllText(filePath)) ?? new();
        else {
            settings = new();
            string directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
            if (!File.Exists(filePath)) { 
                File.Create(filePath).Close();
                File.WriteAllText(filePath, "{}");
            }
        }
    }

    public static void save(string key, object value) {
        settings[key] = value;
        File.WriteAllText(filePath, JsonSerializer.Serialize(settings));
    }

    public static T get<T>(string key) {
        if (settings.TryGetValue(key, out var value)) {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(value));
        }
        return default;
    }
}

