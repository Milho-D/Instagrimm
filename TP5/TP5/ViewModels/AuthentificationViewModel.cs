using System;
using System.Collections.Generic;
using System.Text;
using TP3.ViewModels;
using TP5.Services;
using TP5.Views;
using Xamarin.Forms;

namespace TP5.ViewModels
{
    public class AuthentificationViewModel : SimpleObservableObject
    {
        private string _UserLogin;
        public string UserLogin
        {
            get { return _UserLogin; }
            set {
                if (this.Set(ref this._UserLogin, value)) {
                    this.CmdLogin.ChangeCanExecute();
                }
            }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (this.Set(ref this._Password, value))
                {
                    this.CmdLogin.ChangeCanExecute();
                    this.CmdDelete.ChangeCanExecute();
                }
            }
        }

        public Command CmdLogin { get; set; }
        public Command CmdDelete { get; set; }

        public AuthentificationViewModel()
        {
            this.CmdLogin = new Command(this.Login, this.CanLogin);
            this.CmdDelete = new Command(this.Delete, this.CanDelete);
        }

        private void Login()
        {
            if (AccountService.Instance.Login(this.UserLogin, this.Password))
            {
                Application.Current.MainPage.Navigation.PushAsync(new UserAccountPage());
                this.UserLogin = null;
                this.Password = null;
            } else
            {
                Application.Current.MainPage.DisplayAlert(
                    "Inccorect identifiers",
                    "The identifiers you entered are incorrect", 
                    "OK");
            }
        }
        private bool CanLogin()
        {
            return this.UserLogin != null && this.UserLogin.Length >= 3 &&
                   this.Password != null && this.Password.Length >= 3;
        }

        private void Delete()
        {
            this.Password = null;
        }

        private bool CanDelete()
        {
            return !string.IsNullOrEmpty(this.Password);
        }

    }
}
