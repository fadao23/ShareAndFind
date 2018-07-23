using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAndShare.Models;
using FindAndShare.Services;
using FindAndShare.Views;
using Xamarin.Forms;

namespace FindAndShare.ViewModel
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand Log { get; set; }
        private INavigation _navigation { get; set; }
        private UserLogin userLogin;
        private UserModel User;

        public string Username
        {
            get 
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    SetProperty(ref _username, value); 
                }
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    SetProperty(ref _password, value);
                }
            }
        }
        private string _username;
        private string _password;

        public LoginPageViewModel(INavigation navigation)
        {
            Title = "Login";
            this.userLogin = new UserLogin();
            this._navigation = navigation;
            Log = new Command(async () => await StartLog());

        }

        public async Task StartLog()
        {
            this.User = await this.userLogin.OnLog(this.Username, this.Password);
            if (this.User != null)
            {
                if (this._password.Equals(this.User.Password.S))
                {
                    await this._navigation.PushAsync(new ListPage(this.User));
                }
            }
        }
    }
}
