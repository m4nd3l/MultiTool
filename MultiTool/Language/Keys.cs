namespace MultiTool.Language;

public class Keys {
    public static readonly Key MAIN_MENU = new Key("MultiTool");
    
    public static readonly Key UTILS_MENU = new Key("Utils");
    public static readonly Key CHATBOT_UTILS = new Key("Chatbot");
    public static readonly Key TEXT_CONVERTER_UTILS = new Key("TextConverter");
    public static readonly Key HASH_GENERATOR_UTILS = new Key("HashGenerator");
    public static readonly Key REGEX_TESTER_UTILS = new Key("RegexTester");
    public static readonly Key TIME_UTILITIES_UTILS = new Key("TimeUtilities");
    
    public static readonly Key SYSTEM_MENU = new Key("System");
    public static readonly Key PROCESS_MONITOR_SYSTEM = new Key("ProcessMonitor");
    public static readonly Key HARDWARE_FETCHER_SYSTEM = new Key("HardwareFetcher");
    public static readonly Key ENVIRONMENT_CHECKER_SYSTEM = new Key("EnvironmentChecker");
    public static readonly Key UPTIME_TRACKER_SYSTEM = new Key("UptimeTracker");
    
    public static readonly Key STORAGE_MENU = new Key("Storage");
    public static readonly Key DISK_USER_ANALYZER_STORAGE = new Key("DiskUserAnalyzer");
    public static readonly Key DUPLICATE_FILE_FINDER_STORAGE = new Key("DuplicateFileFinder");
    public static readonly Key FILE_SHREDDER_STORAGE = new Key("FileShredder");
    public static readonly Key DIRECTORY_TREE_STORAGE = new Key("DirectoryTree");
    public static readonly Key FILE_MANIPULATION_STORAGE = new Key("FileManipulation");
    
    public static readonly Key NETWORK_MENU = new Key("Network");
    public static readonly Key API_PLAYGROUND_NETWORK = new Key("ApiPlayground");
    public static readonly Key PORT_SCANNER_NETWORK = new Key("PortScanner");
    public static readonly Key IP_GEOLOCATOR_NETWORK = new Key("IpGeolocator");
    public static readonly Key PING_SPEED_TEST_NETWORK = new Key("PingSpeedTest");
    public static readonly Key DNS_LOOKUP_NETWORK = new Key("DnsLookup");
    
    public static readonly Key DIAGNOSTICS_MENU = new Key("Diagnostics");
    public static readonly Key LOG_ANALYZER_DIAGNOSTICS = new Key("LogAnalyzer");
    public static readonly Key MEMORY_LEAK_DETECTOR_DIAGNOSTICS = new Key("MemoryLeakDetector");
    public static readonly Key PORT_CONFLICT_RESOLVER_DIAGNOSTICS = new Key("PortConflictResolver");
    public static readonly Key CRASH_REPORTER_DIAGNOSTICS = new Key("CrashReporter");
    public static readonly Key SFC_SCANNER_DIAGNOSTICS = new Key("SfcScanner");
    
    public static readonly Key EMERGENCY_MENU = new Key("Emergency");
    public static readonly Key PROCESS_KILLER_EMERGENCY = new Key("ProcessKiller");
    public static readonly Key RAM_FLUSHER_EMERGENCY = new Key("RamFlusher");
    public static readonly Key BACKUP_RESTORER_EMERGENCY = new Key("BackupRestorer");
    public static readonly Key NETWORK_RESETER_EMERGENCY = new Key("NetworkReseter");
    
    public static readonly Key HELP_MENU = new Key("Help");
    public static readonly Key COMMAND_GUIDE_HELP = new Key("CommandGuide");
    public static readonly Key ARGS_HELP = new Key("Args");
    public static readonly Key VERSION_CHECKER_HELP = new Key("VersionChecker");
    
    public static readonly Key SETTINGS_MENU = new Key("Settings");
    public static readonly Key LANGUAGE_SETTINGS = new Key("Language");
    public static readonly Key API_KEYS_SETTINGS = new Key("ApiKeys");
    public static readonly Key LOG_LEVEL_SETTINGS = new Key("LogLevel");
    public static readonly Key RESET_FACTORY_SETTINGS = new Key("ResetFactory");
    public static readonly Key BACKUP_SETTINGS = new Key("Backup");
    public static readonly Key LOAD_SETTINGS = new Key("Load");
    
    public static readonly Key EXIT = new Key("Exit");
    
    public static readonly Key BACK = new Key("Back");

    public static readonly Key EXIT_TO_CLOSE_CHATBOT = new Key("ExitToClose");
    public static readonly Key COMMANDS_CHATBOT = new Key("CommandsChatbot");
    public static readonly Key YOU_CHATBOT = new Key("You");
    public static readonly Key NULL_OR_EMPTY_PROMPT_CHATBOT = new Key("NullOrEmptyPrompt");
    public static readonly Key API_KEY_NOT_FOUND_OR_VALID_CHATBOT = new Key("APIKeyNotFound");
    public static readonly Key ASK_API_KEY_CHATBOT = new Key("ApiKeyQuestion");
    public static readonly Key REQUEST_ERROR_CHATBOT = new Key("RequestError");
    public static readonly Key LOADING_ANSWER_CHATBOT = new Key("LoadingAnswer");
    public static readonly Key SAVE_COMMAND_CHATBOT = new Key("SaveCommand");
    public static readonly Key LOAD_COMMAND_CHATBOT = new Key("LoadCommand");
    public static readonly Key LIST_COMMAND_CHATBOT = new Key("ListCommand");
    public static readonly Key RENAME_COMMAND_CHATBOT = new Key("RenameCommand");
    public static readonly Key DELETE_COMMAND_CHATBOT = new Key("DeleteCommand");
    public static readonly Key MERGE_COMMAND_CHATBOT = new Key("MergeCommand");
    public static readonly Key CLEAR_COMMAND_CHATBOT = new Key("ClearCommand");
    public static readonly Key MODEL_COMMAND_CHATBOT = new Key("ModelCommand");
    public static readonly Key MODELS_COMMAND_CHATBOT = new Key("ModelsCommand");
    public static readonly Key NO_CHAT_SAVED_CHATBOT = new Key("NoChatSaved");
    public static readonly Key NO_CHAT_SAVED_WITH_NAME_CHATBOT = new Key("NoChatSavedWithName");
    public static readonly Key NAME_ALREADY_USED_CHATBOT = new Key("NameAlreadyUsed");
    public static readonly Key ASK_NAME_FOR_SAVING_CHATBOT = new Key("AskNameForSave");
    public static readonly Key ASK_SAVED_CHATBOT = new  Key("AskSaved");
    public static readonly Key ASK_SAVED_FOR_LOAD_CHATBOT = new Key("AskSavedForLoad");
    public static readonly Key ASK_SAVED_FOR_RENAME_CHATBOT = new Key("AskSavedForRename");
    public static readonly Key ASK_NEW_NAME_FOR_RENAME_CHATBOT = new Key("AskNewNameForRename");
    public static readonly Key ASK_SAVED_FOR_DELETE_CHATBOT = new Key("AskSavedForDelete");
    public static readonly Key ASK_SAVED_FOR_MERGE_CHATBOT = new Key("AskSavedForMerge");
    public static readonly Key ASK_MULTIPLE_SAVED_CHATBOT = new Key("AskMultipleSaved");
    public static readonly Key ASK_ADD_THIS_CHAT_CHATBOT = new Key("AddThisChat");
    public static readonly Key ASK_DELETE_SELECTED_CHATS_CHATBOT = new Key("DeleteSingleChats");
    public static readonly Key SHOW_MODEL_CHATBOT = new Key("ShowModel");
    public static readonly Key ASK_MODEL_CHATBOT = new Key("AskNewModel");
    public static readonly Key CURRENT_CHATBOT = new Key("Current");
    public static readonly Key CURRENT_API_KEY_SETTINGS = new Key("CurrentApiKey");
    public static readonly Key EXIT_TO_CLOSE_SETTINGS = new Key("ExitToCloseSettings");
    public static readonly Key ENTER_TEXT = new Key("EnterText");
    public static readonly Key ASK_ACTION = new Key("ActionAsk");
    public static readonly Key PRESS_ENTER_TO_CONTINUE = new Key("EnterToContinue");
    public static readonly Key LOWERCASE = new Key("Lowercase");
    public static readonly Key UPPERCASE = new Key("Uppercase");
    public static readonly Key BASE64_DECODE = new Key("Base64Decode");
    public static readonly Key BASE64_ENCODE = new Key("Base64Encode");
    public static readonly Key INVALID_BASE64_STRING = new Key("InvalidBase64String");
    public static readonly Key BLOODY_FONT = new Key("BloodyFont");
    public static readonly Key RESULT = new Key("Result");
}

public class Key {
    private string key;
    public Key(string key) { this.key = key; }
    public string getKey() => key;
    public override string ToString() => key;
}