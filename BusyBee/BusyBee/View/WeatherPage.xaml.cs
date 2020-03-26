using BusyBee.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusyBee.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
        WeatherViewModel vm;

        public WeatherViewModel ViewModel
        {
            get => vm; set
            {
                vm = value;
                BindingContext = vm;
                Bind();
            }
        }
        public WeatherPage()
        {
            InitializeComponent();
            if (vm == null)
            {
                vm = new WeatherViewModel();
                vm.Init();
            }
        }

        public void Bind()
        {
        }
    }
}