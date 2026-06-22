using MultiTool.Extensions;
using MultiTool.Language;
using MultiTool.ToolUIs;
using MultiTool.ToolUIs.Categories;
using MultiTool.ToolUIs.Categories.Utils;
using Keys = MultiTool.Language.Keys;

namespace MultiTool;

public class AvailableTools {

    // ==========================================
    // 🔨 UTILS
    // ==========================================
    
    private static AvailableToolMenu mainMenu;
    public static AvailableToolMenu MAIN_MENU { get => mainMenu ??= new AvailableToolMenu(Keys.MAIN_MENU, new MainMenu()); }
    
    private static AvailableToolMenu utilsMenu;
    public static AvailableToolMenu UTILS_MENU { get => utilsMenu ??= new AvailableToolMenu(Keys.UTILS_MENU, new UtilsTool()); }
    
    private static AvailableToolMenu chatbotUtils;
    public static AvailableToolMenu CHATBOT_UTILS { get => chatbotUtils ??= new AvailableToolMenu(Keys.CHATBOT_UTILS, new ChatBotPage()); }
    
    private static AvailableToolMenu textConverterUtils;
    public static AvailableToolMenu TEXT_CONVERTER_UTILS { get => textConverterUtils ??= new AvailableToolMenu(Keys.TEXT_CONVERTER_UTILS, new TextConverterPage()); }
    
    private static AvailableTool hashGeneratorUtils;
    public static AvailableTool HASH_GENERATOR_UTILS { get => hashGeneratorUtils ??= new AvailableTool(Keys.HASH_GENERATOR_UTILS); }
    
    private static AvailableTool regexTesterUtils;
    public static AvailableTool REGEX_TESTER_UTILS { get => regexTesterUtils ??= new AvailableTool(Keys.REGEX_TESTER_UTILS); }
    
    private static AvailableTool timeUtilitiesUtils;
    public static AvailableTool TIME_UTILITIES_UTILS { get => timeUtilitiesUtils ??= new AvailableTool(Keys.TIME_UTILITIES_UTILS); }
    
    // ==========================================
    // 💻 SYSTEM
    // ==========================================
    
    private static AvailableToolMenu systemMenu;
    public static AvailableToolMenu SYSTEM_MENU { get => systemMenu ??= new AvailableToolMenu(Keys.SYSTEM_MENU, new SystemTools()); }
    
    private static AvailableTool processMonitorSystem;
    public static AvailableTool PROCESS_MONITOR_SYSTEM { get => processMonitorSystem ??= new AvailableTool(Keys.PROCESS_MONITOR_SYSTEM); }
    
    private static AvailableTool hardwareFetcherSystem;
    public static AvailableTool HARDWARE_FETCHER_SYSTEM { get => hardwareFetcherSystem ??= new AvailableTool(Keys.HARDWARE_FETCHER_SYSTEM); }
    
    private static AvailableTool environmentCheckerSystem;
    public static AvailableTool ENVIRONMENT_CHECKER_SYSTEM { get => environmentCheckerSystem ??= new AvailableTool(Keys.ENVIRONMENT_CHECKER_SYSTEM); }
    
    private static AvailableTool uptimeTrackerSystem;
    public static AvailableTool UPTIME_TRACKER_SYSTEM { get => uptimeTrackerSystem ??= new AvailableTool(Keys.UPTIME_TRACKER_SYSTEM); }
    
    // ==========================================
    // 💾 STORAGE
    // ==========================================
    
    private static AvailableToolMenu storageMenu;
    public static AvailableToolMenu STORAGE_MENU { get => storageMenu ??= new AvailableToolMenu(Keys.STORAGE_MENU, new StorageTools()); }
    
    private static AvailableTool diskUserAnalyzerStorage;
    public static AvailableTool DISK_USER_ANALYZER_STORAGE { get => diskUserAnalyzerStorage ??= new AvailableTool(Keys.DISK_USER_ANALYZER_STORAGE); }
    
    private static AvailableTool duplicateFileFinderStorage;
    public static AvailableTool DUPLICATE_FILE_FINDER_STORAGE { get => duplicateFileFinderStorage ??= new AvailableTool(Keys.DUPLICATE_FILE_FINDER_STORAGE); }
    
    private static AvailableTool fileShredderStorage;
    public static AvailableTool FILE_SHREDDER_STORAGE { get => fileShredderStorage ??= new AvailableTool(Keys.FILE_SHREDDER_STORAGE); }
    
    private static AvailableTool directoryTreeStorage;
    public static AvailableTool DIRECTORY_TREE_STORAGE { get => directoryTreeStorage ??= new AvailableTool(Keys.DIRECTORY_TREE_STORAGE); }
    
    private static AvailableTool fileManipulationStorage;
    public static AvailableTool FILE_MANIPULATION_STORAGE { get => fileManipulationStorage ??= new AvailableTool(Keys.FILE_MANIPULATION_STORAGE); }
    
    // ==========================================
    // 🌐 NETWORK
    // ==========================================
    
    private static AvailableToolMenu networkMenu;
    public static AvailableToolMenu NETWORK_MENU { get => networkMenu ??= new AvailableToolMenu(Keys.NETWORK_MENU, new NetworkTools()); }
    
    private static AvailableTool apiPlaygroundNetwork;
    public static AvailableTool API_PLAYGROUND_NETWORK { get => apiPlaygroundNetwork ??= new AvailableTool(Keys.API_PLAYGROUND_NETWORK); }
    
    private static AvailableTool portScannerNetwork;
    public static AvailableTool PORT_SCANNER_NETWORK { get => portScannerNetwork ??= new AvailableTool(Keys.PORT_SCANNER_NETWORK); }
    
    private static AvailableTool ipGeolocatorNetwork;
    public static AvailableTool IP_GEOLOCATOR_NETWORK { get => ipGeolocatorNetwork ??= new AvailableTool(Keys.IP_GEOLOCATOR_NETWORK); }
    
    private static AvailableTool pingSpeedTestNetwork;
    public static AvailableTool PING_SPEED_TEST_NETWORK { get => pingSpeedTestNetwork ??= new AvailableTool(Keys.PING_SPEED_TEST_NETWORK); }
    
    private static AvailableTool dnsLookupNetwork;
    public static AvailableTool DNS_LOOKUP_NETWORK { get => dnsLookupNetwork ??= new AvailableTool(Keys.DNS_LOOKUP_NETWORK); }
    
    // ==========================================
    // 💔 DIAGNOSTICS
    // ==========================================
    
    private static AvailableToolMenu diagnosticsMenu;
    public static AvailableToolMenu DIAGNOSTICS_MENU { get => diagnosticsMenu ??= new AvailableToolMenu(Keys.DIAGNOSTICS_MENU, new DiagnosticTools()); }
    
    private static AvailableTool logAnalyzerDiagnostics;
    public static AvailableTool LOG_ANALYZER_DIAGNOSTICS { get => logAnalyzerDiagnostics ??= new AvailableTool(Keys.LOG_ANALYZER_DIAGNOSTICS); }
    
    private static AvailableTool memoryLeakDetectorDiagnostics;
    public static AvailableTool MEMORY_LEAK_DETECTOR_DIAGNOSTICS { get => memoryLeakDetectorDiagnostics ??= new AvailableTool(Keys.MEMORY_LEAK_DETECTOR_DIAGNOSTICS); }
    
    private static AvailableTool portConflictResolverDiagnostics;
    public static AvailableTool PORT_CONFLICT_RESOLVER_DIAGNOSTICS { get => portConflictResolverDiagnostics ??= new AvailableTool(Keys.PORT_CONFLICT_RESOLVER_DIAGNOSTICS); }
    
    private static AvailableTool crashReporterDiagnostics;
    public static AvailableTool CRASH_REPORTER_DIAGNOSTICS { get => crashReporterDiagnostics ??= new AvailableTool(Keys.CRASH_REPORTER_DIAGNOSTICS); }
    
    private static AvailableTool sfcScannerDiagnostics;
    public static AvailableTool SFC_SCANNER_DIAGNOSTICS { get => sfcScannerDiagnostics ??= new AvailableTool(Keys.SFC_SCANNER_DIAGNOSTICS); }
    
    // ==========================================
    // 🚨 EMERGENCY
    // ==========================================
    
    private static AvailableToolMenu emergencyMenu;
    public static AvailableToolMenu EMERGENCY_MENU { get => emergencyMenu ??= new AvailableToolMenu(Keys.EMERGENCY_MENU, new EmergencyTools()); }
    
    private static AvailableTool processKillerEmergency;
    public static AvailableTool PROCESS_KILLER_EMERGENCY { get => processKillerEmergency ??= new AvailableTool(Keys.PROCESS_KILLER_EMERGENCY); }
    
    private static AvailableTool ramFlusherEmergency;
    public static AvailableTool RAM_FLUSHER_EMERGENCY { get => ramFlusherEmergency ??= new AvailableTool(Keys.RAM_FLUSHER_EMERGENCY); }
    
    private static AvailableTool backupRestorerEmergency;
    public static AvailableTool BACKUP_RESTORER_EMERGENCY { get => backupRestorerEmergency ??= new AvailableTool(Keys.BACKUP_RESTORER_EMERGENCY); }
    
    private static AvailableTool networkReseterEmergency;
    public static AvailableTool NETWORK_RESETER_EMERGENCY { get => networkReseterEmergency ??= new AvailableTool(Keys.NETWORK_RESETER_EMERGENCY); }
    
    // ==========================================
    // ❓ HELP
    // ==========================================
    
    private static AvailableToolMenu helpMenu;
    public static AvailableToolMenu HELP_MENU { get => helpMenu ??= new AvailableToolMenu(Keys.HELP_MENU, new HelpPage()); }
    
    private static AvailableTool commandGuideHelp;
    public static AvailableTool COMMAND_GUIDE_HELP { get => commandGuideHelp ??= new AvailableTool(Keys.COMMAND_GUIDE_HELP); }
    
    private static AvailableTool argsHelp;
    public static AvailableTool ARGS_HELP { get => argsHelp ??= new AvailableTool(Keys.ARGS_HELP); }
    
    private static AvailableTool versionCheckerHelp;
    public static AvailableTool VERSION_CHECKER_HELP { get => versionCheckerHelp ??= new AvailableTool(Keys.VERSION_CHECKER_HELP); }
    
    // ==========================================
    // ⚙️ SETTINGS
    // ==========================================
    
    private static AvailableToolMenu settingsMenu;
    public static AvailableToolMenu SETTINGS_MENU { get => settingsMenu ??= new AvailableToolMenu(Keys.SETTINGS_MENU, new SettingsPage()); }
    
    private static AvailableTool languageSettings;
    public static AvailableTool LANGUAGE_SETTINGS { get => languageSettings ??= new AvailableTool(Keys.LANGUAGE_SETTINGS); }
    
    private static AvailableTool geminiAPIKeySettings;
    public static AvailableTool GEMINI_API_KEY_SETTINGS { get => geminiAPIKeySettings ??= new AvailableTool(Keys.API_KEYS_SETTINGS); }
        
    private static AvailableTool backupSettings;
    public static AvailableTool BACKUP_SETTINGS { get => backupSettings ??= new AvailableTool(Keys.BACKUP_SETTINGS); }
    
    private static AvailableTool loadSettings;
    public static AvailableTool LOAD_SETTINGS { get => loadSettings ??= new AvailableTool(Keys.LOAD_SETTINGS); }
    
    private static AvailableTool resetFactorySettings;
    public static AvailableTool RESET_FACTORY_SETTINGS { get => resetFactorySettings ??= new AvailableTool(Keys.RESET_FACTORY_SETTINGS); }
    
    // ==========================================
    // 🚪 EXIT
    // ==========================================
    
    private static AvailableToolMenu safeCloseExit;
    public static AvailableToolMenu SAFE_CLOSE_EXIT { get => safeCloseExit ??= new AvailableToolMenu(Keys.EXIT, null); }
    
    // ==========================================
    // ❓ OTHER
    // ==========================================

    private static AvailableTool backToMainMenu;
    public static AvailableTool BACK_TO_MAIN_MENU { get => backToMainMenu ??= new AvailableTool(Keys.BACK); }
}

public class AvailableToolMenu : AvailableTool {
    private Frame menu;
    public AvailableToolMenu(Key key, Frame menu) : base(key) { this.menu = menu; }
    public void switchMenu() => ToolSystem.changeFrame(menu);
}


public class AvailableTool {
    private Key key;
    public AvailableTool(Key key) { this.key = key; }
    public string getName() => this.translate(key);
    public override string ToString() => getName();
}