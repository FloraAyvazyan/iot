using System;

namespace SmartRoomMonitor.Models
{
    public class HistoryRecord
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string EventType { get; set; } = string.Empty; // Login, Logout, PersonDetected, NoPerson, LightOn, LightOff, SettingsChanged
        public string Description { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}