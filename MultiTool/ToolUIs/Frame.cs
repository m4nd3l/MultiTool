using Spectre.Console;
using Windows.Security.Credentials;

namespace MultiTool.ToolUIs;

public abstract class Frame { 
    public abstract void render();
    public void clear() { AnsiConsole.Clear(); }
    public void saveAPIKey(string key) {
        var vault = new PasswordVault();
        var credential = new PasswordCredential("MultiToolAPIKey", "api_key", key);
        vault.Add(credential);
    }
    public string? getAPIKey() {
        try {
            var vault = new PasswordVault();
            var credential = vault.Retrieve("MultiToolAPIKey", "api_key");
            credential.RetrievePassword();
            return credential.Password;
        } catch { return null; }
    }
    public void save(string key, object content) { MultiToolSaving.saveSetting(key, content); }

    public T? read<T>(string key) { return MultiToolSaving.getSetting<T>(key); }
    
    public string promptForFile() {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "All files (*.*)|*.*";
        openFileDialog.Title  = "Select a File";

        if (openFileDialog.ShowDialog() == DialogResult.OK) return openFileDialog.FileName;

        return null;
    }
}
