using System;
using System.IO;

namespace SmartRoomMonitor.Utilities
{
    public static class PathHelper
    {
        private static readonly string BaseDir = AppDomain.CurrentDomain.BaseDirectory;

        public static string DataDir
        {
            get
            {
                string dir = Path.Combine(BaseDir, "Data");
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string LogsDir
        {
            get
            {
                string dir = Path.Combine(BaseDir, "Logs");
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                return dir;
            }
        }

        public static string UsersFile => Path.Combine(DataDir, "users.json");
        public static string SettingsFile => Path.Combine(DataDir, "settings.json");
        public static string HistoryFile => Path.Combine(DataDir, "history.json");
        public static string LogsFile => Path.Combine(DataDir, "logs.json");
    }
}