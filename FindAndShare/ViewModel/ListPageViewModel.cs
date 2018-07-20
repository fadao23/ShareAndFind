using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAndShare.Models;
using FindAndShare.Services;
using FindAndShare.Views;
using Xamarin.Forms;

namespace FindAndShare.ViewModel
{
    public class ListPageViewModel : BaseViewModel
    {
        public ObservableCollection<AnnonceModel> ListAnnonces { get; set; }
        public ICommand AddAnnonce { get; }
        private INavigation _navigation { get; set; }
        public ObservableCollection<AnnonceModel> _listAnonces;
        private AnnoncesServices _webServices;

        public ListPageViewModel(INavigation navigation)
        {
            Title = "Annonces";
            this._navigation = navigation;
            this.ListAnnonces = new ObservableCollection<AnnonceModel>();
            this._webServices = new AnnoncesServices();
            this.AddAnnonce = new Command(async () => await GoToAddPage());
            this.getall();
            MessagingCenter.Subscribe<AddPageViewModel>(this, "PopPage", (sender) => {
                this.ListAnnonces.Clear();
                this.getall();
            });
        }

        private async void getall()
        {
            this._listAnonces = await _webServices.GetAll();
            foreach (var item in this._listAnonces)
                this.ListAnnonces.Add(item);
        }

        public async Task GoToAddPage()
        {
            await this._navigation.PushAsync(new AddPage());
        }
    }
}
