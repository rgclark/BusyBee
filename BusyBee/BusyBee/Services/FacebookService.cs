using BusyBee.Models;
using System.Net.Http;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;
using System;
using Newtonsoft.Json;
using Plugin.FacebookClient;

namespace BusyBee.Services
{
    public class FacebookService
    {
        const string AccessToken = "access_token=";
        const string AccessTokenString = "access_token=";
        //DateTime date = DateTime.Now;
        
        const string EventsUri = "https://graph.facebook.com/v2.10/me/events?"; 
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        
        public FacebookService()
        {
            
        }

        public bool IsLoggedIn()
        {
            return false;
        }
 
        public async Task<FacebookEvent> GetEvent(int id)
        {
            using (var client = new HttpClient())
            {
                var url = EventsUri + AccessTokenString + CrossFacebookClient.Current.ActiveToken; 
                System.Diagnostics.Debug.WriteLine(url);

                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<FacebookEvent>(json);
            }

        }
        private string GetLimitString(DateTime date )
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1); 
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string limitsString;
            TimeSpan fspan = (firstDayOfMonth - epoch);
            TimeSpan lspan = (lastDayOfMonth - epoch);
            return string.Format("&since={0}&until={1}&limit={2}", fspan.TotalSeconds, lspan.TotalSeconds, 400);
        }

        public async Task<FacebookEvents> GetAllEventsForMonth(DateTime date)
        {
            using (var client = new HttpClient())
            {
                //var url = EventsUri + AccessTokenString + BusyBee.Helpers.Settings.FacebookAccessToken + limitsString;
                var url = EventsUri + AccessTokenString + CrossFacebookClient.Current.ActiveToken + GetLimitString(date);
                System.Diagnostics.Debug.WriteLine(url);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<FacebookEvents>(json);
            }

        }

        public async Task<string> GetEmailAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email&access_token={accessToken}");
            var email = JsonConvert.DeserializeObject<FacebookEmail>(json);
            return email.Email;
        }
    }
}
