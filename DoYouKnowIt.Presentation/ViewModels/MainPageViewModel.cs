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
        public MainPageViewModel(ILoginFacade loginFacade)
        {
            _loginFacade = loginFacade;

            GoPlayPageCommand = new Command(async () => { await Shell.Current.GoToAsync(nameof(Views.Play.PlaySelectQuizPage)); });
            //GoLeaderboardPageCommand = new Command(async () => { });
            //GoProfilePageCommand = new Command(async () => { });
            GoQuizBuilderPageCommand = new Command(async () => { await Shell.Current.GoToAsync(nameof(Views.QB.QBSelectPage)); });
            GoCountryFlagLookupPageCommand = new Command(async () => { await Shell.Current.GoToAsync(nameof(Views.ApiNInjas.CountrFlagLookupPage)); });
            LoginCommand = new Command(() => Login(Username, Password));
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

        private void Login(string username, string password)
        {
            if(_loginFacade.UserIsAdmin(username, password))
            {
                Shell.Current.DisplayAlert("Logged in", "Yippi", "OK");
            }
            else
            {
                Shell.Current.DisplayAlert("Login failed", "Not yippi", "OK");
            }
        }
    }
}
