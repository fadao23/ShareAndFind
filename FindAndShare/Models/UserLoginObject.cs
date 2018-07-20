using System;

using Xamarin.Forms;

namespace FindAndShare.Models
{
    public class UserLoginObject : ContentPage
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLoginObject(string password, string username)
        {
            this.Password = password;
            this.Username = username;
        }

    }
}

