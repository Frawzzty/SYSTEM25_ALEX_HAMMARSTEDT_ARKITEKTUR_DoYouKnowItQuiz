
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public MainPage(ViewModels.MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Rotate image on apearing
            ImageLogo.Rotation = 0;
            await ImageLogo.RotateTo(360, 1100, Easing.CubicInOut);
            ImageLogo.Rotation = 0;
        }

    }
}
