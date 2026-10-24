namespace SmartRoomMonitor.Models
{
    public class AppSettings
    {
        public int CountdownSeconds { get; set; } = 30;
        public bool AutoMode { get; set; } = true;
        public bool NotificationsEnabled { get; set; } = true;
        public string LastLoggedInUser { get; set; } = string.Empty;
        public bool RememberLastUser { get; set; } = false;
    }
}