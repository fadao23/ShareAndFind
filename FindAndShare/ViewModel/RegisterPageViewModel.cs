using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAndShare.Models;
using FindAndShare.Services;
using Xamarin.Forms;

namespace FindAndShare.ViewModel
{
    public class RegisterPageViewModel : BaseViewModel
    {

        public ICommand Register { get; } 
        public UserPostModel UserPostModel { get; set; }

        private INavigation _navigation;
        private UserLogin _userServices;
        private Page _page;

        public RegisterPageViewModel(Page page, INavigation navigation)
        {
            Title = "Register";

            this._navigation = navigation;
            this._page = page;
            this.Register = new Command(async () => await RegisterUser());
            this._userServices = new UserLogin();
            this.UserPostModel = new UserPostModel();
        }

        private async Task RegisterUser()
        {

            var result = await this._userServices.OnRegister(this.UserPostModel);
            if (result)
            {
                await this._page.DisplayAlert("You registered successfully", "Please Login for use the app", "Ok");
                await this._navigation.PopToRootAsync();
            }
            else
            {
                await this._page.DisplayAlert("Error in register.", "Please try again.", "Ok");
            }
        }
    }
}

