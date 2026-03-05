
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.MainPageViewModel();


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ImageLogo.Rotation = 0;

            await ImageLogo.RotateTo(360, 1100, Easing.CubicInOut);

            ImageLogo.Rotation = 0;
        }

        private async void OnClickGoQueryTestPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(Views.Test.QueryPropTestPage)}?quizId=4");
        }
    }
}
