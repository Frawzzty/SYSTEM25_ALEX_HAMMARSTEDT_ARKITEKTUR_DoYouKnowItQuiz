
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;

namespace DoYouKnowIt.Presentation
{
    public partial class MainPage : ContentPage
    {
        private IQuizService _quizService;
        public MainPage(IQuizService quizService)
        {
            InitializeComponent();
            _quizService = quizService;

            
        }

        private async void OnClickedPlay(object sender, EventArgs e)
        {
            
        }

        private async void OnClickedProfile(object sender, EventArgs e)
        {

        }

        private async void OnClickedLeaderboard(object sender, EventArgs e)
        {

        }

        private async void OnClickedQuizBuilder(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.QB.QBSelectPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ImageLogo.Rotation = 0;

            await ImageLogo.RotateTo(360, 1100, Easing.CubicInOut);

            ImageLogo.Rotation = 0;
        }
    }
}
