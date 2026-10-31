using iot.Models;
using iot.Utilities;
using SmartRoomMonitor.Models;
using SmartRoomMonitor.Services;
using SmartRoomMonitor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iot.Services
{
    public class HistoryService
    {
        private readonly JsonStorageService _json;
        private readonly List<HistoryRecord> _records;
        private const int MaxRecords = 5000;

        public const string EventLogin = "Login";
        public const string EventLogout = "Logout";
        public const string EventPersonDetected = "PersonDetected";
        public const string EventNoPerson = "NoPerson";
        public const string EventLightOn = "LightOn";
        public const string EventLightOff = "LightOff";
        public const string EventSettingsChanged = "SettingsChanged";

        public HistoryService(JsonStorageService json)
        {
            _json = json;
            _records = _json.ReadList<HistoryRecord>(PathHelper.HistoryFile);
        }

        public void Add(string eventType, string description = "", string username = "")
        {
            try
            {
                var record = new HistoryRecord
                {
                    Timestamp = DateTime.Now,
                    EventType = eventType,
                    Description = description,
                    Username = username
                };

                _records.Add(record);

                if (_records.Count > MaxRecords)
                    _records.RemoveRange(0, _records.Count - MaxRecords);

                _json.Write(PathHelper.HistoryFile, _records);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"History Add Error: {ex.Message}");
            }
        }

        public List<HistoryRecord> GetAll() =>
            _records.OrderByDescending(r => r.Timestamp).ToList();

        public List<HistoryRecord> GetByType(string eventType) =>
            _records.Where(r => r.EventType == eventType)
                    .OrderByDescending(r => r.Timestamp)
                    .ToList();
    }
}