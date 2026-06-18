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
    
    private static AvailableToolMenu mainMenu;
    public static AvailableToolMenu MAIN_MENU { get => mainMenu ??= new AvailableToolMenu(TranslationKeys.MAIN_MENU, new MainMenu()); }
    
    private static AvailableToolMenu utilsMenu;
    public static AvailableToolMenu UTILS_MENU { get => utilsMenu ??= new AvailableToolMenu(TranslationKeys.UTILS_MENU, new UtilsTool()); }
    
    private static AvailableToolMenu chatbotUtils;
    public static AvailableToolMenu CHATBOT_UTILS { get => chatbotUtils ??= new AvailableToolMenu(TranslationKeys.CHATBOT_UTILS, new ChatBotPage()); }
    
    private static AvailableTool textConverterUtils;
    public static AvailableTool TEXT_CONVERTER_UTILS { get => textConverterUtils ??= new AvailableTool(TranslationKeys.TEXT_CONVERTER_UTILS); }
    
    private static AvailableTool hashGeneratorUtils;
    public static AvailableTool HASH_GENERATOR_UTILS { get => hashGeneratorUtils ??= new AvailableTool(TranslationKeys.HASH_GENERATOR_UTILS); }
    
    private static AvailableTool regexTesterUtils;
    public static AvailableTool REGEX_TESTER_UTILS { get => regexTesterUtils ??= new AvailableTool(TranslationKeys.REGEX_TESTER_UTILS); }
    
    private static AvailableTool timeUtilitiesUtils;
    public static AvailableTool TIME_UTILITIES_UTILS { get => timeUtilitiesUtils ??= new AvailableTool(TranslationKeys.TIME_UTILITIES_UTILS); }
    
    // ==========================================
    // 💻 SYSTEM
    // ==========================================
    
    private static AvailableToolMenu systemMenu;
    public static AvailableToolMenu SYSTEM_MENU { get => systemMenu ??= new AvailableToolMenu(TranslationKeys.SYSTEM_MENU, new SystemTools()); }
    
    private static AvailableTool processMonitorSystem;
    public static AvailableTool PROCESS_MONITOR_SYSTEM { get => processMonitorSystem ??= new AvailableTool(TranslationKeys.PROCESS_MONITOR_SYSTEM); }
    
    private static AvailableTool hardwareFetcherSystem;
    public static AvailableTool HARDWARE_FETCHER_SYSTEM { get => hardwareFetcherSystem ??= new AvailableTool(TranslationKeys.HARDWARE_FETCHER_SYSTEM); }
    
    private static AvailableTool environmentCheckerSystem;
    public static AvailableTool ENVIRONMENT_CHECKER_SYSTEM { get => environmentCheckerSystem ??= new AvailableTool(TranslationKeys.ENVIRONMENT_CHECKER_SYSTEM); }
    
    private static AvailableTool uptimeTrackerSystem;
    public static AvailableTool UPTIME_TRACKER_SYSTEM { get => uptimeTrackerSystem ??= new AvailableTool(TranslationKeys.UPTIME_TRACKER_SYSTEM); }
    
    // ==========================================
    // 💾 STORAGE
    // ==========================================
    
    private static AvailableToolMenu storageMenu;
    public static AvailableToolMenu STORAGE_MENU { get => storageMenu ??= new AvailableToolMenu(TranslationKeys.STORAGE_MENU, new StorageTools()); }
    
    private static AvailableTool diskUserAnalyzerStorage;
    public static AvailableTool DISK_USER_ANALYZER_STORAGE { get => diskUserAnalyzerStorage ??= new AvailableTool(TranslationKeys.DISK_USER_ANALYZER_STORAGE); }
    
    private static AvailableTool duplicateFileFinderStorage;
    public static AvailableTool DUPLICATE_FILE_FINDER_STORAGE { get => duplicateFileFinderStorage ??= new AvailableTool(TranslationKeys.DUPLICATE_FILE_FINDER_STORAGE); }
    
    private static AvailableTool fileShredderStorage;
    public static AvailableTool FILE_SHREDDER_STORAGE { get => fileShredderStorage ??= new AvailableTool(TranslationKeys.FILE_SHREDDER_STORAGE); }
    
    private static AvailableTool directoryTreeStorage;
    public static AvailableTool DIRECTORY_TREE_STORAGE { get => directoryTreeStorage ??= new AvailableTool(TranslationKeys.DIRECTORY_TREE_STORAGE); }
    
    private static AvailableTool fileManipulationStorage;
    public static AvailableTool FILE_MANIPULATION_STORAGE { get => fileManipulationStorage ??= new AvailableTool(TranslationKeys.FILE_MANIPULATION_STORAGE); }
    
    // ==========================================
    // 🌐 NETWORK
    // ==========================================
    
    private static AvailableToolMenu networkMenu;
    public static AvailableToolMenu NETWORK_MENU { get => networkMenu ??= new AvailableToolMenu(TranslationKeys.NETWORK_MENU, new NetworkTools()); }
    
    private static AvailableTool apiPlaygroundNetwork;
    public static AvailableTool API_PLAYGROUND_NETWORK { get => apiPlaygroundNetwork ??= new AvailableTool(TranslationKeys.API_PLAYGROUND_NETWORK); }
    
    private static AvailableTool portScannerNetwork;
    public static AvailableTool PORT_SCANNER_NETWORK { get => portScannerNetwork ??= new AvailableTool(TranslationKeys.PORT_SCANNER_NETWORK); }
    
    private static AvailableTool ipGeolocatorNetwork;
    public static AvailableTool IP_GEOLOCATOR_NETWORK { get => ipGeolocatorNetwork ??= new AvailableTool(TranslationKeys.IP_GEOLOCATOR_NETWORK); }
    
    private static AvailableTool pingSpeedTestNetwork;
    public static AvailableTool PING_SPEED_TEST_NETWORK { get => pingSpeedTestNetwork ??= new AvailableTool(TranslationKeys.PING_SPEED_TEST_NETWORK); }
    
    private static AvailableTool dnsLookupNetwork;
    public static AvailableTool DNS_LOOKUP_NETWORK { get => dnsLookupNetwork ??= new AvailableTool(TranslationKeys.DNS_LOOKUP_NETWORK); }
    
    // ==========================================
    // 💔 DIAGNOSTICS
    // ==========================================
    
    private static AvailableToolMenu diagnosticsMenu;
    public static AvailableToolMenu DIAGNOSTICS_MENU { get => diagnosticsMenu ??= new AvailableToolMenu(TranslationKeys.DIAGNOSTICS_MENU, new DiagnosticTools()); }
    
    private static AvailableTool logAnalyzerDiagnostics;
    public static AvailableTool LOG_ANALYZER_DIAGNOSTICS { get => logAnalyzerDiagnostics ??= new AvailableTool(TranslationKeys.LOG_ANALYZER_DIAGNOSTICS); }
    
    private static AvailableTool memoryLeakDetectorDiagnostics;
    public static AvailableTool MEMORY_LEAK_DETECTOR_DIAGNOSTICS { get => memoryLeakDetectorDiagnostics ??= new AvailableTool(TranslationKeys.MEMORY_LEAK_DETECTOR_DIAGNOSTICS); }
    
    private static AvailableTool portConflictResolverDiagnostics;
    public static AvailableTool PORT_CONFLICT_RESOLVER_DIAGNOSTICS { get => portConflictResolverDiagnostics ??= new AvailableTool(TranslationKeys.PORT_CONFLICT_RESOLVER_DIAGNOSTICS); }
    
    private static AvailableTool crashReporterDiagnostics;
    public static AvailableTool CRASH_REPORTER_DIAGNOSTICS { get => crashReporterDiagnostics ??= new AvailableTool(TranslationKeys.CRASH_REPORTER_DIAGNOSTICS); }
    
    private static AvailableTool sfcScannerDiagnostics;
    public static AvailableTool SFC_SCANNER_DIAGNOSTICS { get => sfcScannerDiagnostics ??= new AvailableTool(TranslationKeys.SFC_SCANNER_DIAGNOSTICS); }
    
    // ==========================================
    // 🚨 EMERGENCY
    // ==========================================
    
    private static AvailableToolMenu emergencyMenu;
    public static AvailableToolMenu EMERGENCY_MENU { get => emergencyMenu ??= new AvailableToolMenu(TranslationKeys.EMERGENCY_MENU, new EmergencyTools()); }
    
    private static AvailableTool processKillerEmergency;
    public static AvailableTool PROCESS_KILLER_EMERGENCY { get => processKillerEmergency ??= new AvailableTool(TranslationKeys.PROCESS_KILLER_EMERGENCY); }
    
    private static AvailableTool ramFlusherEmergency;
    public static AvailableTool RAM_FLUSHER_EMERGENCY { get => ramFlusherEmergency ??= new AvailableTool(TranslationKeys.RAM_FLUSHER_EMERGENCY); }
    
    private static AvailableTool backupRestorerEmergency;
    public static AvailableTool BACKUP_RESTORER_EMERGENCY { get => backupRestorerEmergency ??= new AvailableTool(TranslationKeys.BACKUP_RESTORER_EMERGENCY); }
    
    private static AvailableTool networkReseterEmergency;
    public static AvailableTool NETWORK_RESETER_EMERGENCY { get => networkReseterEmergency ??= new AvailableTool(TranslationKeys.NETWORK_RESETER_EMERGENCY); }
    
    // ==========================================
    // ❓ HELP
    // ==========================================
    
    private static AvailableToolMenu helpMenu;
    public static AvailableToolMenu HELP_MENU { get => helpMenu ??= new AvailableToolMenu(TranslationKeys.HELP_MENU, new HelpPage()); }
    
    private static AvailableTool commandGuideHelp;
    public static AvailableTool COMMAND_GUIDE_HELP { get => commandGuideHelp ??= new AvailableTool(TranslationKeys.COMMAND_GUIDE_HELP); }
    
    private static AvailableTool argsHelp;
    public static AvailableTool ARGS_HELP { get => argsHelp ??= new AvailableTool(TranslationKeys.ARGS_HELP); }
    
    private static AvailableTool versionCheckerHelp;
    public static AvailableTool VERSION_CHECKER_HELP { get => versionCheckerHelp ??= new AvailableTool(TranslationKeys.VERSION_CHECKER_HELP); }
    
    // ==========================================
    // ⚙️ SETTINGS
    // ==========================================
    
    private static AvailableToolMenu settingsMenu;
    public static AvailableToolMenu SETTINGS_MENU { get => settingsMenu ??= new AvailableToolMenu(TranslationKeys.SETTINGS_MENU, new SettingsPage()); }
    
    private static AvailableTool languageSettings;
    public static AvailableTool LANGUAGE_SETTINGS { get => languageSettings ??= new AvailableTool(TranslationKeys.LANGUAGE_SETTINGS); }
    
    private static AvailableTool geminiAPIKeySettings;
    public static AvailableTool GEMINI_API_KEY_SETTINGS { get => geminiAPIKeySettings ??= new AvailableTool(TranslationKeys.API_KEYS_SETTINGS); }
        
    private static AvailableTool backupSettings;
    public static AvailableTool BACKUP_SETTINGS { get => backupSettings ??= new AvailableTool(TranslationKeys.BACKUP_SETTINGS); }
    
    private static AvailableTool loadSettings;
    public static AvailableTool LOAD_SETTINGS { get => loadSettings ??= new AvailableTool(TranslationKeys.LOAD_SETTINGS); }
    
    private static AvailableTool resetFactorySettings;
    public static AvailableTool RESET_FACTORY_SETTINGS { get => resetFactorySettings ??= new AvailableTool(TranslationKeys.RESET_FACTORY_SETTINGS); }
    
    // ==========================================
    // 🚪 EXIT
    // ==========================================
    
    private static AvailableToolMenu safeCloseExit;
    public static AvailableToolMenu SAFE_CLOSE_EXIT { get => safeCloseExit ??= new AvailableToolMenu(TranslationKeys.EXIT, null); }
    
    // ==========================================
    // ❓ OTHER
    // ==========================================

    private static AvailableTool backToMainMenu;
    public static AvailableTool BACK_TO_MAIN_MENU { get => backToMainMenu ??= new AvailableTool(TranslationKeys.BACK); }
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