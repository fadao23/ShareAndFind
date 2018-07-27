using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAndShare.Models;
using FindAndShare.Services;
using Xamarin.Forms;

namespace FindAndShare.ViewModel
{
    public class AddPageViewModel : BaseViewModel
    {
        public string title { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }

        public ICommand OnAdd { get; }
        public INavigation navigation { get; }


        private AnnoncePostModel _annonceModel { get; set; }
        private Page _page;
        private AnnoncesServices _annoncesServices;
        private UserModel _user;
        private static Random random = new Random();

        public AddPageViewModel(Page page, INavigation navigation, UserModel user)
        {
            Title = "Add Annonce";
            this.OnAdd = new Command(async () => await OnAddRequest());
            this._annoncesServices = new AnnoncesServices();
            this._annonceModel = new AnnoncePostModel();
            this.navigation = navigation;
            this._page = page;
            this._user = user;
        }

        public async Task OnAddRequest()
        {
            this._annonceModel.Fill(this.title, this.Text, this.Image);
            this._annonceModel.Date = DateTime.Now.ToString();
            this._annonceModel.UserId = this._user.ID.S;
            this._annonceModel.ID = RandomString(32);
            var response = await this._annoncesServices.Post(this._annonceModel);
            if (response)
            {
                await this.navigation.PopAsync();
                MessagingCenter.Send<AddPageViewModel>(this, "PopPage");
            }
            else
                await this._page.DisplayAlert("Error in post.", "Please try again.", "Ok");
        }


        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
