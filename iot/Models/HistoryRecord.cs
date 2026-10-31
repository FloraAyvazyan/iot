using System;

namespace iot.Models   
{
    public class HistoryRecord
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string EventType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}