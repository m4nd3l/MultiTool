namespace MultiTool;

public class AvailableTools {
    // ==========================================
    // 🔨 UTILS
    // ==========================================
    
    /// <summary>A UI Menu to select the tool category.</summary>
    public static AvailableTool MAIN_MENU { get; } = new AvailableTool("Tools");
    
    /// <summary>The main navigation menu for all general utility tools.</summary>
    public static AvailableTool UTILS_MENU { get; } = new AvailableTool("Utils");
    
    /// <summary>An interactive AI chatbot assistant for quick queries directly in the console.</summary>
    public static AvailableTool CHATBOT_UTILS { get; } = new AvailableTool("Chatbot");
    
    /// <summary>Converts text between formats like Base64, Hex, Binary, URL-encoding, and case styles.</summary>
    public static AvailableTool TEXT_CONVERTER_UTILS { get; } = new AvailableTool("TextConverter");
    
    /// <summary>Generates and verifies cryptographic hashes such as MD5, SHA-1, and SHA-256 for strings or files.</summary>
    public static AvailableTool HASH_GENERATOR_UTILS { get; } = new AvailableTool("HashGenerator");
    
    /// <summary>An interactive playground to write, test, and debug Regular Expressions with real-time match highlighting.</summary>
    public static AvailableTool REGEX_TESTER_UTILS { get; } = new AvailableTool("RegexTester");
    
    /// <summary>Handles timezone conversions, epoch timestamp parsing, and date-subtraction calculations.</summary>
    public static AvailableTool TIME_UTILITIES_UTILS { get; } = new AvailableTool("TimeUtilities");
    
    // ==========================================
    // 💻 SYSTEM
    // ==========================================
    
    /// <summary>The main navigation menu for all system information and environment tools.</summary>
    public static AvailableTool SYSTEM_MENU { get; } = new AvailableTool("System");
    
    /// <summary>Displays active system processes with high resource usage (CPU, RAM) in real-time.</summary>
    public static AvailableTool PROCESS_MONITOR_SYSTEM { get; } = new AvailableTool("ProcessMonitor");
    
    /// <summary>Retrieves detailed specifications about local hardware components like CPU, GPU, RAM, and Motherboard.</summary>
    public static AvailableTool HARDWARE_FETCHER_SYSTEM { get; } = new AvailableTool("HardwareFetcher");
    
    /// <summary>Inspects environment variables, OS build version, .NET runtime, and system architecture details.</summary>
    public static AvailableTool ENVIRONMENT_CHECKER_SYSTEM { get; } = new AvailableTool("EnvironmentChecker");
    
    /// <summary>Tracks and displays how long the operating system has been running since its last boot.</summary>
    public static AvailableTool UPTIME_TRACKER_SYSTEM { get; } = new AvailableTool("UptimeTracker");
    
    // ==========================================
    // 💾 STORAGE
    // ==========================================
    
    /// <summary>The main navigation menu for file systems, analyzer, and storage management tools.</summary>
    public static AvailableTool STORAGE_MENU { get; } = new AvailableTool("Storage");
    
    /// <summary>Scans local drives to visualize space allocation and identify large files consuming disk space.</summary>
    public static AvailableTool DISK_USER_ANALYZER_STORAGE { get; } = new AvailableTool("DiskUserAnalyzer");
    
    /// <summary>Scans directories for byte-by-byte identical files to help free up duplicate storage space.</summary>
    public static AvailableTool DUPLICATE_FILE_FINDER_STORAGE { get; } = new AvailableTool("DuplicateFileFinder");
    
    /// <summary>Securely overwrites and deletes sensitive files permanently to prevent data recovery.</summary>
    public static AvailableTool FILE_SHREDDER_STORAGE { get; } = new AvailableTool("FileShredder");
    
    /// <summary>Generates a visual, nested ASCII structural layout diagram of folders and files.</summary>
    public static AvailableTool DIRECTORY_TREE_STORAGE { get; } = new AvailableTool("DirectoryTree");
    
    /// <summary>A hub for basic file system operations including create, edit, remove, copy, and paste.</summary>
    public static AvailableTool FILE_MANIPULATION_STORAGE { get; } = new AvailableTool("FileManipulation");
    
    // ==========================================
    // 🌐 NETWORK
    // ==========================================
    
    /// <summary>The main navigation menu for checking connectivity, APIs, and networking tools.</summary>
    public static AvailableTool NETWORK_MENU { get; } = new AvailableTool("Network");
    
    /// <summary>An API client to send customized HTTP requests (GET, POST, etc.) with custom headers and bodies.</summary>
    public static AvailableTool API_PLAYGROUND_NETWORK { get; } = new AvailableTool("ApiPlayground");
    
    /// <summary>Scans local or remote IP addresses to check for open TCP/UDP network ports.</summary>
    public static AvailableTool PORT_SCANNER_NETWORK { get; } = new AvailableTool("PortScanner");
    
    /// <summary>Fetches geographic and ISP data connected to a specific public IP address.</summary>
    public static AvailableTool IP_GEOLOCATOR_NETWORK { get; } = new AvailableTool("IpGeolocator");
    
    /// <summary>Measures network latency (ping) and estimates current internet download/upload speeds.</summary>
    public static AvailableTool PING_SPEED_TEST_NETWORK { get; } = new AvailableTool("PingSpeedTest");
    
    /// <summary>Queries DNS servers to retrieve A, AAAA, MX, TXT, and CNAME records for a domain.</summary>
    public static AvailableTool DNS_LOOKUP_NETWORK { get; } = new AvailableTool("DnsLookup");
    
    // ==========================================
    // 💔 DIAGNOSTICS
    // ==========================================
    
    /// <summary>The main navigation menu for crash logs, conflict lookups, and integrity diagnostics.</summary>
    public static AvailableTool DIAGNOSTICS_MENU { get; } = new AvailableTool("Diagnostics");
    
    /// <summary>Parses system or application log files to filter, extract, and count errors or warnings.</summary>
    public static AvailableTool LOG_ANALYZER_DIAGNOSTICS { get; } = new AvailableTool("LogAnalyzer");
    
    /// <summary>Monitors RAM allocation trends of specific processes over time to identify continuous resource leakage.</summary>
    public static AvailableTool MEMORY_LEAK_DETECTOR_DIAGNOSTICS { get; } = new AvailableTool("MemoryLeakDetector");
    
    /// <summary>Identifies which background process or PID is currently listening on and blocking a requested network port.</summary>
    public static AvailableTool PORT_CONFLICT_RESOLVER_DIAGNOSTICS { get; } = new AvailableTool("PortConflictResolver");
    
    /// <summary>Generates an isolated debugging summary and memory dump state if the CLI tool crashes.</summary>
    public static AvailableTool CRASH_REPORTER_DIAGNOSTICS { get; } = new AvailableTool("CrashReporter");
    
    /// <summary>Integrates with or mimics System File Checker logic to verify integrity of crucial local file records.</summary>
    public static AvailableTool SFC_SCANNER_DIAGNOSTICS { get; } = new AvailableTool("SfcScanner");
    
    // ==========================================
    // 🚨 EMERGENCY
    // ==========================================
    
    /// <summary>The main navigation menu for rapid recovery and high-priority cleanup operations.</summary>
    public static AvailableTool EMERGENCY_MENU { get; } = new AvailableTool("Emergency");
    
    /// <summary>Forcefully terminates unresponsive, locked, or frozen background processes using PID or exact name.</summary>
    public static AvailableTool PROCESS_KILLER_EMERGENCY { get; } = new AvailableTool("ProcessKiller");
    
    /// <summary>Signals the operating system to clear working standby memory lists to reclaim immediately usable RAM.</summary>
    public static AvailableTool RAM_FLUSHER_EMERGENCY { get; } = new AvailableTool("RamFlusher");
    
    /// <summary>Quickly recovers important tool configuration files or states from a previously saved backup image.</summary>
    public static AvailableTool BACKUP_RESTORER_EMERGENCY { get; } = new AvailableTool("BackupRestorer");
    
    /// <summary>Flushes the DNS cache and restarts local network adapters to recover dropped network links.</summary>
    public static AvailableTool NETWORK_RESETER_EMERGENCY { get; } = new AvailableTool("NetworkReseter");
    
    // ==========================================
    // ❓ HELP
    // ==========================================
    
    /// <summary>The main navigation menu for documentation, arguments, and CLI help info.</summary>
    public static AvailableTool HELP_MENU { get; } = new AvailableTool("Help");
    
    /// <summary>Displays an interactive documentation manual detailing instructions and use cases for every tool.</summary>
    public static AvailableTool COMMAND_GUIDE_HELP { get; } = new AvailableTool("CommandGuide");
    
    /// <summary>Lists all available command-line flags, switches, and direct launch arguments supported by this CLI.</summary>
    public static AvailableTool ARGS_HELP { get; } = new AvailableTool("Args");
    
    /// <summary>Displays the current build version, author credits, application dependencies, and latest changelog updates.</summary>
    public static AvailableTool VERSION_CHECKER_HELP { get; } = new AvailableTool("VersionChecker");
    
    // ==========================================
    // ⚙️ SETTINGS
    // ==========================================
    
    /// <summary>The main navigation menu for configuration properties and customization settings.</summary>
    public static AvailableTool SETTINGS_MENU { get; } = new AvailableTool("Settings");
    
    /// <summary>Changes the display and localization language settings across the CLI environment.</summary>
    public static AvailableTool LANGUAGE_SETTINGS { get; } = new AvailableTool("Language");
    
    /// <summary>Securely saves, updates, or revokes API authentication tokens used by external web integrations.</summary>
    public static AvailableTool API_KEYS_SETTINGS { get; } = new AvailableTool("ApiKeys");
    
    /// <summary>Adjusts the verbosity thresholds (Debug, Info, Warn, Error) for internal background logging.</summary>
    public static AvailableTool LOG_LEVEL_SETTINGS { get; } = new AvailableTool("LogLevel");
    
    /// <summary>Wipes out all local custom configurations, themes, and key stores to restore the tool to out-of-box defaults.</summary>
    public static AvailableTool RESET_FACTORY_SETTINGS { get; } = new AvailableTool("ResetFactory");
    
    // ==========================================
    // 🚪 EXIT
    // ==========================================
    
    /// <summary>Safely writes unsaved buffer caches, terminates running threads, closes active network hooks, and exits.</summary>
    public static AvailableTool SAFE_CLOSE_EXIT { get; } = new AvailableTool("SafeClose");
}

public class AvailableTool {
    public string name;
    public AvailableTool(string name) { this.name = name; }
    public string getName() => name;
    public override string ToString() => name;
}