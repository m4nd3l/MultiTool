using MultiTool.UI.Elements.Basic.Settings;
using MultiTool.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using Windows.Storage;

namespace MultiTool.UI.Elements.Basic;
public abstract class Frame {
    public virtual void initialize() { }
    public abstract void run();
    public void saveAPIKey(string key) {
        var vault = new PasswordVault();
        var credential = new PasswordCredential("MultiToolAPIKey", "api_key", key);
        vault.Add(credential);
    }
    public string getAPIKey() {
        try {
            var vault = new PasswordVault();
            var credential = vault.Retrieve("MultiToolAPIKey", "api_key");
            credential.RetrievePassword();
            return credential.Password;
        } catch { return "None"; }
    }
    public void save(string key, object content) {
        MultiToolSettings.save(key, content);
    }

    public T? read<T>(string key) {
        return MultiToolSettings.get<T>(key);
    }
}