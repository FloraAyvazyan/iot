using System;
using SmartRoomMonitor.Models;
using SmartRoomMonitor.Utilities;

namespace SmartRoomMonitor.Services
{
    public class SettingsService
    {
        private readonly JsonStorageService _json;
        private AppSettings _settings;

        public SettingsService(JsonStorageService json)
        {
            _json = json;
            _settings = _json.Read(PathHelper.SettingsFile, new AppSettings());
        }

        public AppSettings Current => _settings;

        public void Save(AppSettings newSettings)
        {
            if (newSettings == null) throw new ArgumentNullException(nameof(newSettings));
            _settings = newSettings;
            _json.Write(PathHelper.SettingsFile, _settings);
        }

        public void Reload()
        {
            _settings = _json.Read(PathHelper.SettingsFile, new AppSettings());
        }
    }
}