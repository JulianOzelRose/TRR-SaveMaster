namespace TRR_SaveMaster
{
    public class Globals
    {
        // Application metadata & configuration
        public const string WINDOW_TITLE = "Tomb Raider I-VI Remastered Savegame Editor";
        public const string CONFIG_FILE_NAME = "TRR-SaveMaster.ini";
        public const string VERSION = "2.80";

        // Config file keys
        public const string CONFIG_KEY_TRX_PATH = "TRXPath=";
        public const string CONFIG_KEY_TRX2_PATH = "TRX2Path=";
        public const string CONFIG_KEY_AUTO_BACKUP = "AutoBackup=";
        public const string CONFIG_KEY_PLATFORM = "Platform=";
        public const string CONFIG_KEY_STATUS_BAR = "StatusBar=";
        public const string CONFIG_KEY_TR6_INVENTORY_TOGGLE = "ShowInventoryToggleTR6=";
        public const string CONFIG_KEY_DARK_MODE = "DarkMode=";

        // Tab IDs
        public const int TAB_TR1 = 0;
        public const int TAB_TR2 = 1;
        public const int TAB_TR3 = 2;
        public const int TAB_TR4 = 3;
        public const int TAB_TR5 = 4;
        public const int TAB_TR6 = 5;

        // Savefile sizes
        public const int SAVEFILE_SIZE_TRX_PREPATCH = 0x152004;
        public const int SAVEFILE_SIZE_TRX_PATCH5 = 0x272004;
        public const int SAVEFILE_SIZE_TRX2 = 0x3DCA04;

        // Savegame slot sizes and constants
        public const int MAX_SAVEGAMES = 32;
        public const int SAVEGAME_SIZE_TRX_PREPATCH = 0x3800;
        public const int SAVEGAME_SIZE_TRX_PATCH5 = 0x6800;
        public const int SAVEGAME_SIZE_TRX2 = 0xA470;

        // Savefile & savegame header
        public const int SAVEFILE_VERSION_OFFSET = 0x000;
        public const int SLOT_STATUS_OFFSET = 0x004;
        public const byte SAVEFILE_TRX_PREPATCH = 0x3B;
        public const byte SAVEFILE_TRX_PATCH5 = 0x3C;
        public const byte SAVEFILE_TRX2_FORMAT = 0x28;

        // Challenge Mode constants
        public const byte CHALLENGE_MODE_ENEMY_NUMBERS_NORMAL = 3;
        public const byte CHALLENGE_MODE_ENEMY_TYPE_NORMAL = 2;
        public const byte CHALLENGE_MODE_ENEMY_TYPE_RANDOMIZER = 5;

        // Entity constants
        public const int LARA_ENTITY_ID = 0;

        // Links
        public const string GITHUB_LINK = "https://github.com/JulianOzelRose";
        public const string GITHUB_README_LINK = "https://github.com/JulianOzelRose/TRR-SaveMaster/blob/master/README.md";
        public const string GITHUB_REPORT_BUG_LINK = "https://github.com/JulianOzelRose/TRR-SaveMaster/issues";

        // Dialog messages & titles
        public const string DIALOG_MSG_CONFIRM_SAVEGAME_CHANGES = "Would you like to apply changes to the savegame?";
        public const string DIALOG_MSG_CONFIRM_SAVEGAME_DELETE = "Are you sure you wish to delete";
        public const string DIALOG_MSG_SAVEGAME_FILE_NOT_FOUND = "Could not find savegame file.";
        public const string DIALOG_MSG_SAVEGAME_NOT_FOUND = "Savegame no longer present.";
        public const string DIALOG_MSG_SAVEGAME_NOT_FOUND_REFRESH_REQUIRED = "Savegame no longer present. Press OK to refresh savegame list.";
        public const string DIALOG_MSG_POSITION_NOT_FOUND = "Unable to locate position data. Try saving the game while Lara is standing.";
        public const string DIALOG_MSG_CANNOT_EDIT_POSITION_IN_VEHICLE = "Cannot edit position while Lara is in a vehicle.";
        public const string DIALOG_MSG_INVALID_SAVEGAME_FILE_TRX = "Not a valid Tomb Raider I–III Remastered savegame file.";
        public const string DIALOG_MSG_INVALID_SAVEGAME_FILE_TRX2 = "Not a valid Tomb Raider IV–VI Remastered savegame file.";
        public const string DIALOG_MSG_SAVEGAME_PATH_NOT_SET_TRX = "Tomb Raider I–III savegame file path has not been set. Would you like to set it now?";
        public const string DIALOG_MSG_SAVEGAME_PATH_NOT_SET_TRX2 = "Tomb Raider IV–VI savegame file path has not been set. Would you like to set it now?";
        public const string DIALOG_TITLE_CONFIRMATION = "Confirmation";
        public const string DIALOG_TITLE_ERROR = "Error";
        public const string DIALOG_TITLE_POSITION_NOT_FOUND = "Position Not Found";
        public const string DIALOG_TITLE_CANNOT_EDIT_POSITION = "Cannot Edit Position";
        public const string DIALOG_TITLE_PLATFORM_NOT_SUPPORTED = "Platform Not Supported";
        public const string DIALOG_TITLE_SAVEGAME_FILE_VERSION_NOT_SUPPORTED = "Unsupported Savegame File Version";
        public const string DIALOG_TITLE_INVALID_SAVEGAME_FILE = "Invalid Savegame File";
        public const string DIALOG_TITLE_SAVEGAME_PATH_NOT_SET = "Savegame Path Not Set";

        // Status messages
        public const string STATUS_MSG_READY = "Ready";
        public const string STATUS_MSG_SAVEGAME_FILE_LOAD_SUCCESS = "Loaded savegame file:";
        public const string STATUS_MSG_SAVEGAME_FILE_BACKUP_SUCCESS = "Created savegame backup:";
        public const string STATUS_MSG_SAVEGAME_READ_SUCCESS = "Successfully loaded savegame:";
        public const string STATUS_MSG_SAVEGAME_READ_ERROR = "Error retrieving savegame data";
        public const string STATUS_MSG_SAVEGAME_WRITE_SUCCESS = "Successfully patched savegame:";
        public const string STATUS_MSG_SAVEGAME_WRITE_ERROR = "Error writing to savegame";
        public const string STATUS_MSG_SAVEGAME_DELETE_SUCCESS = "Successfully deleted savegame:";
        public const string STATUS_MSG_SAVEGAME_DELETE_ERROR = "Error deleting savegame";
        public const string STATUS_MSG_STATISTICS_READ_ERROR = "Error loading savegame statistics";
        public const string STATUS_MSG_STATISTICS_WRITE_SUCCESS = "Successfully patched statistics of savegame:";
        public const string STATUS_MSG_STATISTICS_WRITE_ERROR = "Error writing to savegame statistics";
        public const string STATUS_MSG_POSITION_READ_ERROR = "Error retrieving savegame position data";
        public const string STATUS_MSG_POSITION_WRITE_SUCCESS = "Successfully patched position data of savegame:";
        public const string STATUS_MSG_POSITION_WRITE_ERROR = "Error writing to savegame position data";
        public const string STATUS_MSG_GLOBALS_READ_ERROR = "Error loading savegame globals";
        public const string STATUS_MSG_GLOBALS_WRITE_SUCCESS = "Successfully patched savegame globals";
        public const string STATUS_MSG_GLOBALS_WRITE_ERROR = "Error writing to savegame globals";
        public const string STATUS_MSG_OUTFITS_READ_ERROR = "Error loading outfits data";
        public const string STATUS_MSG_OUTFITS_WRITE_SUCCESS = "Successfully patched outfits data";
        public const string STATUS_MSG_OUTFITS_WRITE_ERROR = "Error writing to outfits data";

        // Internal error messages
        public const string ERROR_MSG_INVALID_LZW_HEADER = "Invalid LZW header. Savegame is possibly corrupt.";
        public const string ERROR_MSG_SAVEGAME_BUFFER_NULL_OR_EMPTY = "Savegame buffer is null or empty.";
        public const string ERROR_MSG_SAVEGAME_BUFFER_WRITE_ERROR = "Error while writing to buffer:";
        public const string ERROR_MSG_MISSING_LEVEL_DEFINITION = "FATAL: Missing level definition for level";
        public const string ERROR_MSG_MISSING_OBJECT_DEFINITION = "FATAL: Missing object definition";
    }
}
