namespace BusyBee
{
    public static class Constants
    {
        public static string AppName = "Busy Bee";

        public static string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        public static string OpenWeatherMapAPIKey = "<insert open weather key>";

        // OAuth
        // For Google login, configure at https://console.developers.google.com/
        public static string iOSClientId = "<insert IOS client ID here>";
		public static string AndroidClientId = "<insert Android client ID here>";

        public static string fbiOSClientId = "1659227674127381";
        public static string fbAndroidClientId = "<insert Android client ID here>";

        // These values do not need changing
        public static string Scope = "https://www.googleapis.com/auth/userinfo.email";
		public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
		public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
		public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

		// Set these to reversed iOS/Android client ids, with :/oauth2redirect appended
		public static string iOSRedirectUrl = "<insert IOS redirect URL here>:/oauth2redirect";
        public static string AndroidRedirectUrl = "<insert Android redirect URL here>:/oauth2redirect";
    }
}
