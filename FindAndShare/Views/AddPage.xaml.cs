using System;
using System.Collections.Generic;
using FindAndShare.Models;
using FindAndShare.ViewModel;
using Xamarin.Forms;

namespace FindAndShare.Views
{
    public partial class AddPage : ContentPage
    {
        public AddPage(UserModel user)
        {
            InitializeComponent();
            BindingContext = new AddPageViewModel(this, Navigation, user);
        }
    }
}
