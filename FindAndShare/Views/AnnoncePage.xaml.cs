using System;
using System.Collections.Generic;
using FindAndShare.Models;
using FindAndShare.ViewModel;
using Xamarin.Forms;

namespace FindAndShare.Views
{
    public partial class AnnoncePage : ContentPage
    {
        public AnnoncePage(AnnonceModel annonce)
        {
            InitializeComponent();
            BindingContext = new AnnoncePageViewModel(Navigation, annonce);
        }
    }
}
