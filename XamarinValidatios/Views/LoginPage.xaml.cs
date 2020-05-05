using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinValidatios.ViewModels;

namespace XamarinValidatios.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}
