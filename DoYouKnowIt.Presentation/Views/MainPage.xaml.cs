
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;

namespace DoYouKnowIt.Presentation
{
    public partial class MainPage : ContentPage
    {
        IQuizService _quizService;
        public MainPage(IQuizService quizService)
        {
            InitializeComponent();
            _quizService = quizService;

            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await LoadQuizzes();
        }

        private async Task LoadQuizzes()
        {
            CollectionViewQuiz.ItemsSource = await _quizService.GetAllQuizzesAsync();
        }

        private async void OnClickAddQuiz(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EntryTitle.Text) && !string.IsNullOrWhiteSpace(EntryDescription.Text) && !string.IsNullOrWhiteSpace(EntryImageUrl.Text))
            {
                await _quizService.CreateQuizAsync(new Quiz()
                {
                    Title = EntryTitle.Text,
                    Description = EntryDescription.Text,
                    ImageUrl = EntryImageUrl.Text,
                });

                EntryTitle.Text = "";
                EntryDescription.Text = "";
                EntryImageUrl.Text = "";

                await LoadQuizzes();
            }
            else
            {
                await DisplayAlert("Error", "Make sure entries are not empty", "OK");
            }


        }

        private async void OnClickDeleteQuiz(object sender, EventArgs e)
        {
            await _quizService.DeleteQuizAsync(int.Parse(EntryQuizId.Text));
            await LoadQuizzes();
        }
    }
}
