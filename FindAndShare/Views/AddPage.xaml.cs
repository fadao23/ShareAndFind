using System;
using System.Collections.Generic;
using FindAndShare.ViewModel;
using Xamarin.Forms;

namespace FindAndShare.Views
{
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
            BindingContext = new AddPageViewModel(this, Navigation);
        }
    }
}
