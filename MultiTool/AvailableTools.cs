using MultiTool.Extensions;
using MultiTool.Language;
using MultiTool.ToolUIs;
using MultiTool.ToolUIs.Categories;
using MultiTool.ToolUIs.Categories.Utils;

namespace MultiTool;

public class AvailableTools {
    // ==========================================
    // 🔨 UTILS
    // ==========================================
    
    /// <summary>A UI Menu to select the tool category.</summary>
    public static AvailableToolMenu MAIN_MENU => new AvailableToolMenu(TranslationKeys.MAIN_MENU, new MainMenu());
    
    /// <summary>The main navigation menu for all general utility tools.</summary>
    public static AvailableToolMenu UTILS_MENU => new AvailableToolMenu(TranslationKeys.UTILS_MENU, new UtilsTool());
    
    /// <summary>An interactive AI chatbot assistant for quick queries directly in the console.</summary>
    public static AvailableToolMenu CHATBOT_UTILS => new AvailableToolMenu(TranslationKeys.CHATBOT_UTILS, new ChatBotPage());
    
    /// <summary>Converts text between formats like Base64, Hex, Binary, URL-encoding, and case styles.</summary>
    public static AvailableTool TEXT_CONVERTER_UTILS => new AvailableTool(TranslationKeys.TEXT_CONVERTER_UTILS);
    
    /// <summary>Generates and verifies cryptographic hashes such as MD5, SHA-1, and SHA-256 for strings or files.</summary>
    public static AvailableTool HASH_GENERATOR_UTILS => new AvailableTool(TranslationKeys.HASH_GENERATOR_UTILS);
    
    /// <summary>An interactive playground to write, test, and debug Regular Expressions with real-time match highlighting.</summary>
    public static AvailableTool REGEX_TESTER_UTILS => new AvailableTool(TranslationKeys.REGEX_TESTER_UTILS);
    
    /// <summary>Handles timezone conversions, epoch timestamp parsing, and date-subtraction calculations.</summary>
    public static AvailableTool TIME_UTILITIES_UTILS => new AvailableTool(TranslationKeys.TIME_UTILITIES_UTILS);
    
    // ==========================================
    // 💻 SYSTEM
    // ==========================================
    
    /// <summary>The main navigation menu for all system information and environment tools.</summary>
    public static AvailableToolMenu SYSTEM_MENU => new AvailableToolMenu(TranslationKeys.SYSTEM_MENU, new SystemTools());
    
    /// <summary>Displays active system processes with high resource usage (CPU, RAM) in real-time.</summary>
    public static AvailableTool PROCESS_MONITOR_SYSTEM => new AvailableTool(TranslationKeys.PROCESS_MONITOR_SYSTEM);
    
    /// <summary>Retrieves detailed specifications about local hardware components like CPU, GPU, RAM, and Motherboard.</summary>
    public static AvailableTool HARDWARE_FETCHER_SYSTEM => new AvailableTool(TranslationKeys.HARDWARE_FETCHER_SYSTEM);
    
    /// <summary>Inspects environment variables, OS build version, .NET runtime, and system architecture details.</summary>
    public static AvailableTool ENVIRONMENT_CHECKER_SYSTEM => new AvailableTool(TranslationKeys.ENVIRONMENT_CHECKER_SYSTEM);
    
    /// <summary>Tracks and displays how long the operating system has been running since its last boot.</summary>
    public static AvailableTool UPTIME_TRACKER_SYSTEM => new AvailableTool(TranslationKeys.UPTIME_TRACKER_SYSTEM);
    
    // ==========================================
    // 💾 STORAGE
    // ==========================================
    
    /// <summary>The main navigation menu for file systems, analyzer, and storage management tools.</summary>
    public static AvailableToolMenu STORAGE_MENU => new AvailableToolMenu(TranslationKeys.STORAGE_MENU, new StorageTools());
    
    /// <summary>Scans local drives to visualize space allocation and identify large files consuming disk space.</summary>
    public static AvailableTool DISK_USER_ANALYZER_STORAGE => new AvailableTool(TranslationKeys.DISK_USER_ANALYZER_STORAGE);
    
    /// <summary>Scans directories for byte-by-byte identical files to help free up duplicate storage space.</summary>
    public static AvailableTool DUPLICATE_FILE_FINDER_STORAGE => new AvailableTool(TranslationKeys.DUPLICATE_FILE_FINDER_STORAGE);
    
    /// <summary>Securely overwrites and deletes sensitive files permanently to prevent data recovery.</summary>
    public static AvailableTool FILE_SHREDDER_STORAGE => new AvailableTool(TranslationKeys.FILE_SHREDDER_STORAGE);
    
    /// <summary>Generates a visual, nested ASCII structural layout diagram of folders and files.</summary>
    public static AvailableTool DIRECTORY_TREE_STORAGE => new AvailableTool(TranslationKeys.DIRECTORY_TREE_STORAGE);
    
    /// <summary>A hub for basic file system operations including create, edit, remove, copy, and paste.</summary>
    public static AvailableTool FILE_MANIPULATION_STORAGE => new AvailableTool(TranslationKeys.FILE_MANIPULATION_STORAGE);
    
    // ==========================================
    // 🌐 NETWORK
    // ==========================================
    
    /// <summary>The main navigation menu for checking connectivity, APIs, and networking tools.</summary>
    public static AvailableToolMenu NETWORK_MENU => new AvailableToolMenu(TranslationKeys.NETWORK_MENU, new NetworkTools());
    
    /// <summary>An API client to send customized HTTP requests (GET, POST, etc.) with custom headers and bodies.</summary>
    public static AvailableTool API_PLAYGROUND_NETWORK => new AvailableTool(TranslationKeys.API_PLAYGROUND_NETWORK);
    
    /// <summary>Scans local or remote IP addresses to check for open TCP/UDP network ports.</summary>
    public static AvailableTool PORT_SCANNER_NETWORK => new AvailableTool(TranslationKeys.PORT_SCANNER_NETWORK);
    
    /// <summary>Fetches geographic and ISP data connected to a specific public IP address.</summary>
    public static AvailableTool IP_GEOLOCATOR_NETWORK => new AvailableTool(TranslationKeys.IP_GEOLOCATOR_NETWORK);
    
    /// <summary>Measures network latency (ping) and estimates current internet download/upload speeds.</summary>
    public static AvailableTool PING_SPEED_TEST_NETWORK => new AvailableTool(TranslationKeys.PING_SPEED_TEST_NETWORK);
    
    /// <summary>Queries DNS servers to retrieve A, AAAA, MX, TXT, and CNAME records for a domain.</summary>
    public static AvailableTool DNS_LOOKUP_NETWORK => new AvailableTool(TranslationKeys.DNS_LOOKUP_NETWORK);
    
    // ==========================================
    // 💔 DIAGNOSTICS
    // ==========================================
    
    /// <summary>The main navigation menu for crash logs, conflict lookups, and integrity diagnostics.</summary>
    public static AvailableToolMenu DIAGNOSTICS_MENU => new AvailableToolMenu(TranslationKeys.DIAGNOSTICS_MENU, new DiagnosticTools());
    
    /// <summary>Parses system or application log files to filter, extract, and count errors or warnings.</summary>
    public static AvailableTool LOG_ANALYZER_DIAGNOSTICS => new AvailableTool(TranslationKeys.LOG_ANALYZER_DIAGNOSTICS);
    
    /// <summary>Monitors RAM allocation trends of specific processes over time to identify continuous resource leakage.</summary>
    public static AvailableTool MEMORY_LEAK_DETECTOR_DIAGNOSTICS => new AvailableTool(TranslationKeys.MEMORY_LEAK_DETECTOR_DIAGNOSTICS);
    
    /// <summary>Identifies which background process or PID is currently listening on and blocking a requested network port.</summary>
    public static AvailableTool PORT_CONFLICT_RESOLVER_DIAGNOSTICS => new AvailableTool(TranslationKeys.PORT_CONFLICT_RESOLVER_DIAGNOSTICS);
    
    /// <summary>Generates an isolated debugging summary and memory dump state if the CLI tool crashes.</summary>
    public static AvailableTool CRASH_REPORTER_DIAGNOSTICS => new AvailableTool(TranslationKeys.CRASH_REPORTER_DIAGNOSTICS);
    
    /// <summary>Integrates with or mimics System File Checker logic to verify integrity of crucial local file records.</summary>
    public static AvailableTool SFC_SCANNER_DIAGNOSTICS => new AvailableTool(TranslationKeys.SFC_SCANNER_DIAGNOSTICS);
    
    // ==========================================
    // 🚨 EMERGENCY
    // ==========================================
    
    /// <summary>The main navigation menu for rapid recovery and high-priority cleanup operations.</summary>
    public static AvailableToolMenu EMERGENCY_MENU => new AvailableToolMenu(TranslationKeys.EMERGENCY_MENU, new EmergencyTools());
    
    /// <summary>Forcefully terminates unresponsive, locked, or frozen background processes using PID or exact name.</summary>
    public static AvailableTool PROCESS_KILLER_EMERGENCY => new AvailableTool(TranslationKeys.PROCESS_KILLER_EMERGENCY);
    
    /// <summary>Signals the operating system to clear working standby memory lists to reclaim immediately usable RAM.</summary>
    public static AvailableTool RAM_FLUSHER_EMERGENCY => new AvailableTool(TranslationKeys.RAM_FLUSHER_EMERGENCY);
    
    /// <summary>Quickly recovers important tool configuration files or states from a previously saved backup image.</summary>
    public static AvailableTool BACKUP_RESTORER_EMERGENCY => new AvailableTool(TranslationKeys.BACKUP_RESTORER_EMERGENCY);
    
    /// <summary>Flushes the DNS cache and restarts local network adapters to recover dropped network links.</summary>
    public static AvailableTool NETWORK_RESETER_EMERGENCY => new AvailableTool(TranslationKeys.NETWORK_RESETER_EMERGENCY);
    
    // ==========================================
    // ❓ HELP
    // ==========================================
    
    /// <summary>The main navigation menu for documentation, arguments, and CLI help info.</summary>
    public static AvailableToolMenu HELP_MENU => new AvailableToolMenu(TranslationKeys.HELP_MENU, new HelpPage());
    
    /// <summary>Displays an interactive documentation manual detailing instructions and use cases for every tool.</summary>
    public static AvailableTool COMMAND_GUIDE_HELP => new AvailableTool(TranslationKeys.COMMAND_GUIDE_HELP);
    
    /// <summary>Lists all available command-line flags, switches, and direct launch arguments supported by this CLI.</summary>
    public static AvailableTool ARGS_HELP => new AvailableTool(TranslationKeys.ARGS_HELP);
    
    /// <summary>Displays the current build version, author credits, application dependencies, and latest changelog updates.</summary>
    public static AvailableTool VERSION_CHECKER_HELP => new AvailableTool(TranslationKeys.VERSION_CHECKER_HELP);
    
    // ==========================================
    // ⚙️ SETTINGS
    // ==========================================
    
    /// <summary>The main navigation menu for configuration properties and customization settings.</summary>
    public static AvailableToolMenu SETTINGS_MENU => new AvailableToolMenu(TranslationKeys.SETTINGS_MENU, new SettingsPage());
    
    /// <summary>Changes the display and localization language settings across the CLI environment.</summary>
    public static AvailableTool LANGUAGE_SETTINGS => new AvailableTool(TranslationKeys.LANGUAGE_SETTINGS);
    
    /// <summary>Securely saves, updates, or revokes API authentication tokens used by external web integrations.</summary>
    public static AvailableTool API_KEYS_SETTINGS => new AvailableTool(TranslationKeys.API_KEYS_SETTINGS);
    
    /// <summary>Adjusts the verbosity thresholds (Debug, Info, Warn, Error) for internal background logging.</summary>
    public static AvailableTool LOG_LEVEL_SETTINGS => new AvailableTool(TranslationKeys.LOG_LEVEL_SETTINGS);
        
    /// <summary>Saves current settings.</summary>
    public static AvailableTool BACKUP_SETTINGS => new AvailableTool(TranslationKeys.BACKUP_SETTINGS);
    
    /// <summary>Loads settings from .cfg file.</summary>
    public static AvailableTool LOAD_SETTINGS => new AvailableTool(TranslationKeys.LOAD_SETTINGS);
    
    /// <summary>Wipes out all local custom configurations, themes, and key stores to restore the tool to out-of-box defaults.</summary>
    public static AvailableTool RESET_FACTORY_SETTINGS => new AvailableTool(TranslationKeys.RESET_FACTORY_SETTINGS);
    
    // ==========================================
    // 🚪 EXIT
    // ==========================================
    
    /// <summary>Safely writes unsaved buffer caches, terminates running threads, closes active network hooks, and exits.</summary>
    public static AvailableToolMenu SAFE_CLOSE_EXIT => new AvailableToolMenu(TranslationKeys.EXIT, new ExitPage());
    
    // ==========================================
    // ❓ OTHER
    // ==========================================
    
    /// <summary>Safely writes unsaved buffer caches, terminates running threads, closes active network hooks, and exits.</summary>
    public static AvailableTool BACK_TO_MAIN_MENU => new AvailableTool(TranslationKeys.BACK);
}

public class AvailableToolMenu : AvailableTool {
    private Frame menu;
    public AvailableToolMenu(Key key, Frame menu) : base(key) { this.menu = menu; }
    public Frame getMenu() => menu;
}

public class AvailableTool {
    private Key key;
    public AvailableTool(Key key) { this.key = key; }
    public string getName() => this.translate(key);
    public override string ToString() => getName();
}