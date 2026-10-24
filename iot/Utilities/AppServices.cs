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

        // სხვა სერვისები მოგვიანებით დაემატება (LightController, SensorSimulationService და ა.შ.)
        //public static LightController Light { get; private set; }
        //public static SensorSimulationService Sensor { get; private set; }

        public static void Initialize()
        {
            Json = new JsonStorageService();
            Logger = new LoggerService(Json);
            History = new HistoryService(Json);
            Settings = new SettingsService(Json);
            Users = new UserService(Json);
            Auth = new AuthenticationService(Users, Logger, History);

            // Light და Sensor მოგვიანებით შეიქმნება (ნაწილი 3-4)
        }

        // ხელახლა ჩატვირთვა (თუ საჭიროა)
        public static void ReloadAll()
        {
            Users.Reload();
            Settings.Reload();
        }
    }
}