using System;
using System.Collections.Generic;
using System.Text;
using TP5.Models;
using Xamarin.Forms;

namespace TP5.Services
{
    public class AccountService
    {
        private AccountService() { }
        private static AccountService _Instance;

        public static AccountService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountService();
                }
                return _Instance;
            }
        }

        private User _CurrentUser;

        public User GetCurrentUser()
        {
            return _CurrentUser;
        }

        public bool IsAuthentificated()
        {
            return this.GetCurrentUser() != null;
        }

        public void Logoff()
        {
            this._CurrentUser = null;
            Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        public bool Login(string userLogin, string password)
        {
            if (userLogin == "milho" && password == "milho")
            {
                this._CurrentUser = new User()
                {
                    Id = 1,
                    Login = "milho",
                    Password = "milho",
                    Email = "milho@mail.com",
                };
                return true;
            }
            return false;
        }
    }
}
