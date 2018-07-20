using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAndShare.ViewModel;
using Xamarin.Forms;

namespace FindAndShare
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
