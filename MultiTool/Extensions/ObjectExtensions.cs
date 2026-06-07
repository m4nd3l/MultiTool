using MultiTool.Language;

namespace MultiTool.Extensions;

public static class ObjectExtensions {
    public static string translate(this Object obj, Key key) { return LanguageManager.getTranslation(key); }
    public static string translate(this Key obj) { return LanguageManager.getTranslation(obj); }
}
