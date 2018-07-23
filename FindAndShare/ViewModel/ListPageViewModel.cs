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
        public ICommand OnClick { get; }
        public ObservableCollection<AnnonceModel> _listAnonces;

        AnnonceModel _selectedItem;
        public AnnonceModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
                GoToAnnonce();

            }
        }

        private INavigation _navigation { get; set; }
        private AnnoncesServices _webServices;
        private UserModel _user;

        public ListPageViewModel(INavigation navigation, UserModel user)
        {
            Title = "Annonces";
            this._navigation = navigation;
            this.ListAnnonces = new ObservableCollection<AnnonceModel>();
            this._webServices = new AnnoncesServices();
            this.AddAnnonce = new Command(async () => await GoToAddPage());
            this._user = user;
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
            await this._navigation.PushAsync(new AddPage(this._user));
        }

        public async void GoToAnnonce()
        {
            await this._navigation.PushAsync(new AnnoncePage(SelectedItem));
        }
    }
}
