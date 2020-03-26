// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace BusyBee.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

        #region Setting Constants

        private const string IsImperialKey = "is_imperial";
        private static readonly bool IsImperialDefault = true;


        private const string UseCityKey = "use_city";
        private static readonly bool UseCityDefault = true;


        private const string CityKey = "city";
        private static readonly string CityDefault = "Seattle,WA";

        const string LastSyncKey = "last_sync";
        static readonly DateTime LastSyncDefault = DateTime.Now.AddDays(-30);


        const string UserIdKey = "userid";
        static readonly string UserIdDefault = string.Empty;

        const string AuthTokenKey = "authtoken";
        static readonly string AuthTokenDefault = string.Empty;

        const string LoginAttemptsKey = "login_attempts";
        const int LoginAttemptsDefault = 0;

        const string NeedsSyncKey = "needs_sync";
        const bool NeedsSyncDefault = true;

        const string HasSyncedDataKey = "has_synced";
        const bool HasSyncedDataDefault = false;

        #endregion

        public static string AuthToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(AuthTokenKey, AuthTokenDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(AuthTokenKey, value);
            }
        }


        public static string FacebookAccessToken
        {
            get => AppSettings.GetValueOrDefault(nameof(FacebookAccessToken), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(FacebookAccessToken), value);

        }

        public static string UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserIdKey, UserIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserIdKey, value);
            }
        }

        public static bool IsLoggedIn
        {
            get
            {
                //if (!AzureService.UseAuth)
                    //return true;

                return !string.IsNullOrWhiteSpace(UserId);
            }
        }


        public static bool IsImperial
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsImperialKey, IsImperialDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsImperialKey, value);
            }
        }


  

        public static string City
        {
            get
            {
                return AppSettings.GetValueOrDefault(CityKey, CityDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(CityKey, value);
            }
        }


    }
}