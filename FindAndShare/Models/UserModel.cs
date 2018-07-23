using System;
using System.ComponentModel;
using Foundation;
using Xamarin.Forms;

namespace FindAndShare.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public StringModel City 
        { 
            get { return _city; }
            set 
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }

        public StringModel ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public StringModel Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public StringModel Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }


        private StringModel _city { get; set; }
        private StringModel _id { get; set; }
        private StringModel _email { get; set; }
        private StringModel _password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

