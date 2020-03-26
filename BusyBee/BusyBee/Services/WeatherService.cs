using BusyBee.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace BusyBee.Services
{
    public enum Units
    {
        Imperial,
        Metric
    }

    public class WeatherService
    {
        const string WeatherCoordinatesUri = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units={2}&appid={3}";
        const string WeatherCityUri = "https://api.openweathermap.org/data/2.5/weather?q={0}&units={1}&appid={2}";
        const string ForecaseUri = "https://api.openweathermap.org/data/2.5/forecast?id={0}&units={1}&appid={2}";


//        {
//        "coord":{"lon":-105.02,"lat":39.79},
//        "weather":[{"id":600,"main":"Snow","description":"light snow","icon":"13n"}],
//        "base":"stations",
//        "main":{"temp":33.26,"feels_like":22.89,"temp_min":25,"temp_max":37.99,"pressure":1010,"humidity":69},
//        "visibility":1609,
//        "wind":{"speed":10.29,"deg":330},
//"clouds":{"all":90},
//"dt":1584149530,
//"sys":{"type":1,"id":3444,"country":"US","sunrise":1584105233,"sunset":1584147901},
//"timezone":-21600,
//"id":5413519,
//"name":"Berkley",
//"cod":200
//}
        public async Task<WeatherRoot> GetWeather(double latitude, double longitude, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(WeatherCoordinatesUri, latitude, longitude, units.ToString().ToLower(), Constants.OpenWeatherMapAPIKey);
                try
                {
                    var json =  await client.GetStringAsync(url);

                    if (string.IsNullOrWhiteSpace(json))
                        return null;
                
                return DeserializeObject<WeatherRoot>(json);
                }
                catch (Exception ex)
                {
                // change info.plist 
                //https://stackoverflow.com/questions/32631184/the-resource-could-not-be-loaded-because-the-app-transport-security-policy-requi

                    Console.WriteLine(ex.Message);
                }
                return null;
            }

        }

        public async Task<WeatherRoot> GetWeather(string city, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(WeatherCityUri, city, units.ToString().ToLower(), Constants.OpenWeatherMapAPIKey);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<WeatherRoot>(json);
            }

        }

        public async Task<WeatherForecastRoot> GetForecast(int id, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(ForecaseUri, id, units.ToString().ToLower(), Constants.OpenWeatherMapAPIKey);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<WeatherForecastRoot>(json);
            }

        }
    }
}
