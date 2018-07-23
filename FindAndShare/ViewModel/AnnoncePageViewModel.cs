using System;
using FindAndShare.Models;
using Xamarin.Forms;

namespace FindAndShare.ViewModel
{
    public class AnnoncePageViewModel : BaseViewModel
    {

        public AnnonceModel Annonce { get; set; }

        public AnnoncePageViewModel(INavigation navigation, AnnonceModel annonce)
        {
            
            this.Annonce = annonce;
            if (!annonce.Equals(null))
                Title = Annonce.Title.S;
        }
    }
}
