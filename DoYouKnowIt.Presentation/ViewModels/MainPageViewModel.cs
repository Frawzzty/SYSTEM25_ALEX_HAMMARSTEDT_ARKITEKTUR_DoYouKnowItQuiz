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
    class MainPageViewModel : INotifyPropertyChanged
    {

        public MainPageViewModel()
        {


            GoPlayPageCommand = new Command(async () => { await Shell.Current.GoToAsync(nameof(Views.Play.PlaySelectQuizPage)); });
            //GoLeaderboardPageCommand = new Command(async () => { });
            //GoProfilePageCommand = new Command(async () => { });
            GoQuizBuilderPageCommand = new Command(async () => { await Shell.Current.GoToAsync(nameof(Views.QB.QBSelectPage)); });
            GoCountryFlagLookupPageCommand = new Command(async () => { await Shell.Current.GoToAsync(nameof(Views.ApiNInjas.CountrFlagLookupPage)); });

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
        #endregion
    }
}
