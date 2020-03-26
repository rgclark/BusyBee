using BusyBee.Helpers;
using BusyBee.Models;
using BusyBee.Services;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace BusyBee.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        WeatherService WeatherService { get; } = new WeatherService();
        public int Temp { get; set; }
        public WeatherViewModel()
        {
        }

        string location = Settings.City;
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged();
                Settings.City = value;
            }
        }

        bool useGPS = true;
        public bool UseGPS
        {
            get { return useGPS; }
            set
            {
                useGPS = value;
                OnPropertyChanged();
            }
        }


        bool isImperial = Settings.IsImperial;
        public bool IsImperial
        {
            get { return isImperial; }
            set
            {
                isImperial = value;
                OnPropertyChanged();
                Settings.IsImperial = value;
            }
        }


        string city = string.Empty;
        public string DisplayCity
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        string temp = string.Empty;
        public string DisplayTemp
        {
            get { return temp; }
            set { temp = value;
                OnPropertyChanged();
            }
        }

        double tempValue = 0;
        public double TempValue
        {
            get { return tempValue; }
            set { tempValue = value; OnPropertyChanged(); }
        }

        double humidity = 0;
        public double Humidity
        {
            get { return humidity; }
            set { humidity = value; OnPropertyChanged(); }
        }

        string condition = string.Empty;
        public string Condition
        {
            get { return condition; }
            set { condition = value; OnPropertyChanged(); }
        }



        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        ObservableCollection<WeatherRoot> forecast = new ObservableCollection<WeatherRoot>();
        public ObservableCollection<WeatherRoot> Forecast
        {
            get { return forecast; }
            set { forecast = value; OnPropertyChanged(); }
        }


        ICommand getWeather;
        public ICommand GetWeatherCommand =>
                getWeather ??
                (getWeather = new Command(async () => await ExecuteGetWeatherCommand()));

        public async Task ExecuteGetWeatherCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                WeatherRoot weatherRoot = null;
                var units = IsImperial ? Units.Imperial : Units.Metric;

                if (UseGPS)
                {

                    //var gps = await CrossGeolocator.Current.GetPositionAsync(1000);
                    //var gps = await Geolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(10));
                    var gps = await Geolocation.GetLocationAsync();
                    weatherRoot = await WeatherService.GetWeather(gps.Latitude, gps.Longitude, units);
                }
                else
                {
                    //Get weather by city
                    weatherRoot = await WeatherService.GetWeather(Location.Trim(), units);
                }

                

                //await Task.Delay(500);

                //Get forecast based on cityId
                var fullForecast = await WeatherService.GetForecast(weatherRoot.CityId, units);
                Forecast.Clear();
                foreach (var item in fullForecast.Items)
                    Forecast.Add(item);

                var unit = IsImperial ? "F" : "C";
                TempValue = weatherRoot?.MainWeather?.Temperature ?? 0;
                Humidity = weatherRoot?.MainWeather?.Humidity ?? 0;
                DisplayTemp = $"{weatherRoot?.MainWeather?.Temperature ?? 0}°{unit}";
                Condition = $"{weatherRoot.Name}: {weatherRoot?.Weather?[0]?.Description ?? string.Empty}";
                DisplayCity = weatherRoot?.Name;
                UpdateCalendar();

            }
            catch (Exception ex)
            {
                DisplayTemp = "Unable to get Weather";
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void Init()
        {
            GetWeatherCommand.Execute(null);
        }

        public CalendarEventCollection CalEvents { get; set; } = new CalendarEventCollection();

        void UpdateCalendar()
        {
            var events = Forecast.Select(i => new CalendarInlineEvent
            {
                StartTime = DateTime.Parse(i.Date).ToLocalTime(),
                EndTime = DateTime.Parse(i.Date).AddHours(3).ToLocalTime(),
                Subject = i.DisplayTemp,
                Color = i.MainWeather.Temperature > 80 ? Color.Red : (i.MainWeather.Temperature > 60 ? Color.Yellow : Color.Blue)
            });
            CalEvents.Clear();
            foreach (var ev in events)
                CalEvents.Add(ev);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
