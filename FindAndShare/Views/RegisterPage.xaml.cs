using System;
using System.Collections.Generic;
using FindAndShare.ViewModel;
using Xamarin.Forms;

namespace FindAndShare.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterPageViewModel(this, Navigation);
        }
    }
}
