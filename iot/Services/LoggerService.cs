using System;
using System.Collections.Generic;
using System.Linq;
using SmartRoomMonitor.Models;
using SmartRoomMonitor.Utilities;

namespace SmartRoomMonitor.Services
{
    public class LoggerService
    {
        private readonly JsonStorageService _json;
        private readonly List<LogRecord> _logs;
        private const int MaxLogs = 2000; // ძალიან გაზრდის თავიდან ასარიდებლად

        public LoggerService(JsonStorageService json)
        {
            _json = json;
            _logs = _json.ReadList<LogRecord>(PathHelper.LogsFile);
        }

        public void Log(string message, string level = "Info", string category = "General", string username = "", Exception ex = null)
        {
            try
            {
                var record = new LogRecord
                {
                    Timestamp = DateTime.Now,
                    Level = level,
                    Category = category,
                    Message = message,
                    Username = username,
                    Exception = ex?.ToString() ?? string.Empty
                };

                _logs.Add(record);

                // ძალიან ბევრი ლოგი რომ არ დაგროვდეს
                if (_logs.Count > MaxLogs)
                {
                    _logs.RemoveRange(0, _logs.Count - MaxLogs);
                }

                _json.Write(PathHelper.LogsFile, _logs);
            }
            catch
            {
                // ლოგირების შეცდომა არ უნდა ამტვრიოს პროგრამას
            }
        }

        public void LogInfo(string message, string category = "General", string username = "")
            => Log(message, "Info", category, username);

        public void LogWarning(string message, string category = "General", string username = "")
            => Log(message, "Warning", category, username);

        public void LogError(string message, Exception ex = null, string category = "General", string username = "")
            => Log(message, "Error", category, username, ex);

        public List<LogRecord> GetAll() => _logs.OrderByDescending(l => l.Timestamp).ToList();
    }
}