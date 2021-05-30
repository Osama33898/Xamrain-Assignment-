using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Assignment
{
    /// <summary>  
    /// This is the Settings static class that can be used in your Core solution or in any  
    /// of your client applications. All settings are laid out the same exact way with getters  
    /// and setters.   
    /// </summary>  
    public static class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }

        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }

        public static string MobileNumber
        {
            get => AppSettings.GetValueOrDefault(nameof(MobileNumber), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(MobileNumber), value);
        }

        public static void ClearAllData()
        {
            AppSettings.Clear();
        }

    }
}