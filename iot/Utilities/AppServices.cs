using iot.Managers; // ⬅️ ეს ხაზი დაამატე
using iot.Services;
using SmartRoomMonitor.Services;

namespace iot.Utilities
{
    public static class AppServices
    {
        public static JsonStorageService Json { get; private set; }
        public static LoggerService Logger { get; private set; }
        public static HistoryService History { get; private set; }
        public static SettingsService Settings { get; private set; }
        public static UserService Users { get; private set; }
        public static AuthenticationService Auth { get; private set; }

        public static SensorSimulationService Sensor { get; private set; }
        public static LightController Light { get; private set; }

        public static CountdownManager Countdown { get; private set; } // ⬅️ ეს დავამატეთ

        public static void Initialize()
        {
            Json = new JsonStorageService();
            Logger = new LoggerService(Json);
            History = new HistoryService(Json);
            Settings = new SettingsService(Json);
            Users = new UserService(Json);
            Auth = new AuthenticationService(Users, Logger, History);

            Sensor = new SensorSimulationService();
            Light = new LightController();

            Countdown = new CountdownManager(); // ⬅️ ეს დავამატეთ
        }

        public static void ReloadAll()
        {
            Users.Reload();
            Settings.Reload();
        }
    }
}