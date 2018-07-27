using System;
using System.Collections.Generic;
using FindAndShare.ViewModel;
using Xamarin.Forms;

namespace FindAndShare.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginPageViewModel(this, Navigation);
        }
    }
}
