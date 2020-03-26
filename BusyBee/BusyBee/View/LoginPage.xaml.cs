using BusyBee.ViewModels;
using System;
using Xamarin.Forms;

namespace BusyBee.View
{
    public partial class LoginPage : ContentPage
    {

        private LoginViewModel vm;

        public LoginViewModel VM
        {
            get { return vm; }
            set
            {
                vm = VM;
                BindingContext = vm;
            }
        }

        public LoginPage()
        {

            InitializeComponent();
            var newVM = new LoginViewModel() { };
            newVM.OnLoginSuccessful += OnLoginSuccess;
            VM = newVM;

           
        }

        public void OnLoginSuccess(object sender, EventArgs e)
        {
            App.GoToCoffee();
        }
    }
}
