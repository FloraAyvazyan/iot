using iot.Utilities;

namespace iot.Services
{
    public static class LanguageService
    {
        public static bool IsEnglish => AppServices.Settings.Current.Language == "EN";

        public static void SetLanguage(string langCode)
        {
            var settings = AppServices.Settings.Current;
            settings.Language = langCode;
            AppServices.Settings.Save(settings);
        }

        // ეს მეთოდი იღებს ქართულს და ინგლისურს, და აბრუნებს იმას, რომელი ენაც არჩეულია
        public static string T(string kaText, string enText)
        {
            return IsEnglish ? enText : kaText;
        }
    }
}