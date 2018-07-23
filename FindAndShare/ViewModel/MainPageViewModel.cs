using System;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAndShare.Views;
using Xamarin.Forms;

namespace FindAndShare.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        
        public ICommand LoginPage { get; }
        public ICommand RegisterPage { get; }
        private INavigation _navigation { get; set; }

        public MainPageViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            LoginPage = new Command(async () => await GoToLoginPage());
            RegisterPage = new Command(async () => await GoToRegisterPage());
        }

        private async Task GoToRegisterPage()
        {
            await this._navigation.PushAsync(new RegisterPage());
        }

        public async Task GoToLoginPage()
        {
            await this._navigation.PushAsync(new LoginPage());
        }
    }
}
