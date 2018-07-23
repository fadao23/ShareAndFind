using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FindAndShare.ViewModel;
using FindAndShare.Models;

namespace FindAndShare.Views
{
    public partial class ListPage : ContentPage
    {
        public ListPage(UserModel user)
        {
            InitializeComponent();
            BindingContext = new ListPageViewModel(Navigation, user);
            NavigationPage.SetHasBackButton(this, false);

        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ListView.SelectedItem = null;
        }

    }
}
