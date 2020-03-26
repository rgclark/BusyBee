using BusyBee.View;
using Plugin.FacebookClient;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BusyBee
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjA5OUAzMTM2MmUzMjJlMzBtUnA0NTB4Sm1jM3RyZE9VbHpzYkRLOXF3UGlpVmI3N2d0VThKc29UVkJJPQ==");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTMzNjg4QDMxMzcyZTMyMmUzMFMyU3F4Z0s3VnhxRExNK2pyWHBYWmF3ZEN1ZWo5RTZFU3o4cHZPREVxTVU9");
            InitializeComponent();


            if (CrossFacebookClient.Current.IsLoggedIn)
            {
                //https://graph.facebook.com/v2.10/me/events?access_token=&since=1564617600&until=1567209600&limit=400
                var navPage = new CustomNavigationPage();
                navPage.Navigation.PushAsync(new MainPage());
                MainPage = navPage;
                //App.GoToCoffee();
            }
            else
            {
                var navPage = new CustomNavigationPage();
                navPage.Navigation.PushAsync(new WeatherPage());
                MainPage = navPage;
            }
        }

        public static void GoToCoffee()
        {
            Current.MainPage = new NavigationPage(new CalendarPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#F2C500")
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
