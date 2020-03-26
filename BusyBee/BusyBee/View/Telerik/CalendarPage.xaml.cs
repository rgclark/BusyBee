using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BusyBee.ViewModels;

using Syncfusion.SfCalendar.XForms;

namespace BusyBee.Telerik
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

            if (Device.OS == TargetPlatform.iOS)
                Icon = new FileImageSource { File = "tab3.png" };

            var  eventsCalendar  = this.FindByName<SfCalendar>("EventsCalendar");
            //eventsCalendar.SetMonthViewItemChangedListener(new SfCalendar.MonthViewItemChangedListener());

            VM.ExecuteGetFacebookEventsCommand(DateTime.Now);
        }
        
    }
}