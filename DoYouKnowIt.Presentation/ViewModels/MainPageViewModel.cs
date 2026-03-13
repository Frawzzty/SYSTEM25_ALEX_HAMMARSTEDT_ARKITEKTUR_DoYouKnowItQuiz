using Domain.Entities.Models;
using DoYouKnowIt.Application.Facades;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        ILoginFacade _loginFacade;
        UserSession _userSession;
        public MainPageViewModel(ILoginFacade loginFacade, UserSession userSession)
        {
            _loginFacade = loginFacade;
            _userSession = userSession;

            GoPlayPageCommand = new Command(async () => { await Shell.Current.GoToAsync(nameof(Views.Play.PlaySelectQuizPage)); });
            //GoLeaderboardPageCommand = new Command(async () => { });
            //GoProfilePageCommand = new Command(async () => { });
            GoQuizBuilderPageCommand = new Command(async () => { await Shell.Current.GoToAsync(nameof(Views.QB.QBSelectPage)); });
            GoCountryFlagLookupPageCommand = new Command(async () => { await GoApiPage(); });
            LoginCommand = new Command(() => Login());
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Commands
        public ICommand GoPlayPageCommand { get; set; }
        //public ICommand GoLeaderboardPageCommand { get; set; }
        //public ICommand GoProfilePageCommand { get; set; }
        public ICommand GoQuizBuilderPageCommand { get; set; }
        public ICommand GoCountryFlagLookupPageCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        #endregion

        private string _username;
        private string _password;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }

        //Login
        public async Task<bool> Login()
        {
            if (!IsValidLoginInputs())
                return false;

            if (await _loginFacade.UserLogin(Username, Password))
            {
                Shell.Current.DisplayAlert("Login status", "You are now logged in", "OK");
                Username = "";
                Password = "";
                return true;
            }
            else
            {
                Shell.Current.DisplayAlert("Login status", "Login failed, check username and password is correct", "OK");
            }

            return false;
        }

        //Logout
        public void Logout()
        {
            _loginFacade.UserLogout();
        }

        //Api page locked behind Admin permission
        private async Task GoApiPage()
        {

            if (await _loginFacade.UserIsAdminAsync(_userSession.Username, _userSession.Password))
            {
                await Shell.Current.GoToAsync(nameof(Views.ApiNInjas.CountrFlagLookupPage));
            }
            else
            {
                Shell.Current.DisplayAlert("Error", "Please login with an Admin account", "OK");
            }
                
        }

        //Input validation
        private bool IsValidLoginInputs()
        {
            if (!string.IsNullOrEmpty(Username) || !string.IsNullOrEmpty(Password))
                return true;
            
            Shell.Current.DisplayAlert("Error", "Fill in Username and Password", "OK");
            return false;
            
        }

    }
}
