using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BusyBee.ViewModels;

using Syncfusion.SfCalendar.XForms;
using BusyBee.View;

namespace BusyBee.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        FacebookViewModel VM { get; set; }

        public CalendarPage()
        {
            InitializeComponent();

            BindingContext = new FacebookViewModel();
            VM = (FacebookViewModel)BindingContext;

            //if (Device.OS ==  TargetPlatform.iOS)
                //IconImageSource = new FileImageSource { File = "tab3.png" };

         
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await VM.ExecuteGetFacebookEventsCommand(DateTime.Now);
        }

        public async void Handle_OnMonthCellLoaded(object sender, MonthCellLoadedEventArgs args)
        {
            var x = args.Date;
            await VM.ExecuteGetFacebookEventsCommand(x);
        }

        private async void EventsCalendar_MonthInlineAppointmentTapped(object sender, Syncfusion.SfSchedule.XForms.MonthInlineAppointmentTappedEventArgs e)
        {
            var newPage = new EventPage();
            Navigation.PushModalAsync(newPage);
            
        }

        private async void EventsCalendar_VisibleDatesChangedEvent(object sender, Syncfusion.SfSchedule.XForms.VisibleDatesChangedEventArgs e)
        {
            var date = e.visibleDates.ElementAt(e.visibleDates.Count() / 2);
            await VM.ExecuteGetFacebookEventsCommand(date);
        }
    }
}