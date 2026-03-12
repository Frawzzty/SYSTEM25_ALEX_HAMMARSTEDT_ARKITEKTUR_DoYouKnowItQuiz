
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using Microsoft.VisualBasic;
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

        private async void OnClickedLogin(object sender, EventArgs e)
        {
            if(BindingContext is ViewModels.MainPageViewModel vm)
            {
                if(await vm.Login())
                {
                    entryUsername.IsVisible = false;
                    entryPassword.IsVisible = false;

                    btnLogin.IsVisible = false;
                    btnLogout.IsVisible = true;
                }
            }
        }

        private async void OnClickedLogout(object sender, EventArgs e)
        {
            if (BindingContext is ViewModels.MainPageViewModel vm)
            {
                vm.Logout();

                entryUsername.IsVisible = true;
                entryPassword.IsVisible = true;

                btnLogin.IsVisible = true;
                btnLogout.IsVisible = false;
            }
        }
    }
}
