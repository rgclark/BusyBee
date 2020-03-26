using BusyBee.Helpers;
using BusyBee.Models;
using BusyBee.Services;
using Syncfusion.SfCalendar.XForms;
using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BusyBee
{
    public class FacebookViewModel : INotifyPropertyChanged
    {
        FacebookService FacebookService { get; } = new FacebookService();
        
        public ICommand OnFacebookLoginSuccessCmd { get; }
        public ICommand OnFacebookLoginErrorCmd { get; }
        public ICommand OnFacebookLoginCancelCmd { get; }
        public event EventHandler<EventArgs> OnLoginSuccessful;

        public ICommand ScheduleVisibleDatesChanged { get; set; }
         
        private DateTime StartDate;
        private DateTime EndDate;


        void DisplayAlert(string title, string msg) =>
            (Application.Current as App).MainPage.DisplayAlert(title, msg, "OK");

        public FacebookViewModel()
        {
            OnFacebookLoginSuccessCmd = new Command<string>(
             (authToken) => {
                 //DisplayAlert("Success", $"Authentication succeed: {authToken}");
                 OnLoginSuccessful?.Invoke(this, new EventArgs());
             });

            ScheduleVisibleDatesChanged = new Command<VisibleDatesChangedEventArgs>(VisibleDatesChanged);

            OnFacebookLoginErrorCmd = new Command<string>(
                (err) => DisplayAlert("Error", $"Authentication failed: {err}"));

            OnFacebookLoginCancelCmd = new Command(
                () => DisplayAlert("Cancel", "Authentication cancelled by the user."));
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

        bool useGPS;
        public bool UseGPS
        {
            get { return useGPS; }
            set
            {
                useGPS = value;
                OnPropertyChanged();
            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }


        ObservableCollection<FacebookEvent> myEvents = new ObservableCollection<FacebookEvent>();
        public ObservableCollection<FacebookEvent> MyEvents
        {
            get { return myEvents; }
            set { myEvents = value; OnPropertyChanged(); }
        }


        private bool SameDay(DateTime first, DateTime second)
        {
            return (first.Day == second.Day && first.Year == second.Year && first.Month == second.Month);

        }
        public async Task ExecuteGetFacebookEventsCommand()
        {
            Console.WriteLine("here");
        }
        public async Task ExecuteGetFacebookEventsCommand(DateTime date)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                //DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                //DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                //if (SameDay(firstDayOfMonth, StartDate) == false || SameDay(lastDayOfMonth, EndDate))
                //{
                    //StartDate = firstDayOfMonth;
                    //EndDate = lastDayOfMonth;
                    var fullEvents = await FacebookService.GetAllEventsForMonth(date);

                    MyEvents.Clear();
                    foreach (var item in fullEvents.Items)
                        MyEvents.Add(item);

                    UpdateCalendar();
                //}

            }
            catch (Exception ex)
            {
                var ErrorMessage = "Unable to get Events";
            }
            finally
            {
                IsBusy = false;
            }
        }


        private async void VisibleDatesChanged(VisibleDatesChangedEventArgs args)
        {
            var visibleDates = args.visibleDates;
            var date = visibleDates.ElementAt(visibleDates.Count() / 2);
            await ExecuteGetFacebookEventsCommand(date);
        }

        public CalendarEventCollection CalEvents { get; set; } = new CalendarEventCollection();
        public ScheduleAppointmentCollection ScheduleEvents { get; set; } = new ScheduleAppointmentCollection();

        void UpdateCalendar()
        {
            var events = MyEvents.Select(i => new CalendarInlineEvent
            {
                StartTime = i.StartTime.ToLocalTime(),
                EndTime = i.StartTime.AddHours(3).ToLocalTime(),//i.EndTime.ToLocalTime(),
                Subject = i.Name,
                Color = i.RSVPStatus == "attending" ? Color.Blue : Color.Red
            });
            CalEvents.Clear();
            ScheduleEvents.Clear();

            foreach (var ev in MyEvents)
            {
                CalEvents.Add(new CalendarInlineEvent()
                {
                    StartTime = ev.StartTime.ToLocalTime(),
                    EndTime = ev.EndTime.AddHours(3).ToLocalTime(),
                    Subject = ev.Name,
                    Color = ev.RSVPStatus == "attending" ? Color.Blue : Color.Red
                });
                ScheduleEvents.Add(new ScheduleAppointment()
                {
                    StartTime = ev.StartTime.ToLocalTime(),
                    EndTime = ev.EndTime.AddHours(3).ToLocalTime(),
                    Subject = ev.Name,
                    Notes = ev.Id,
                    Color = ev.RSVPStatus == "attending" ? Color.Blue : Color.Red
                });
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
