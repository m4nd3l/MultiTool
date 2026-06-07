namespace MultiTool.Language;

public class LanguageData {
    public string                     name { get; set; }
    public Dictionary<string, string> keys { get; set; }

    public string get(Key key) => keys == null ? "Unknown" : keys[key.getKey()];
}
