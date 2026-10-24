using System;

namespace SmartRoomMonitor.Models
{
    public class LogRecord
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Level { get; set; } = "Info"; // Info, Warning, Error
        public string Category { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;
    }
}