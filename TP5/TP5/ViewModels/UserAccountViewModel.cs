using System;
using System.Collections.Generic;
using System.Text;
using TP5.Models;
using TP5.Services;
using Xamarin.Forms;

namespace TP5.ViewModels
{
    public class UserAccountViewModel
    {
        private User _User;

        public string Email { get => this._User?.Email; }
        public string WelcomeMessage { get => $"Bienvenue à toi {this._User?.Login} !"; }

        public Command CmdLogoff { get; set; }

        public UserAccountViewModel()
        {
            if (!AccountService.Instance.IsAuthentificated())
            {
                Application.Current.MainPage.Navigation.PopToRootAsync();
                return;
            }

            this._User = AccountService.Instance.GetCurrentUser();

            this.CmdLogoff = new Command(() => AccountService.Instance.Logoff());
        }
    }
}
