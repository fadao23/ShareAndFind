using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FindAndShare.ViewModel;

namespace FindAndShare.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel(Navigation);
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
