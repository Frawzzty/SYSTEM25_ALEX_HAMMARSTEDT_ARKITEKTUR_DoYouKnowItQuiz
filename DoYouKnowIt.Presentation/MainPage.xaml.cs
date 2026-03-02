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

        private async void OnClickedGetData(object sender, EventArgs e)
        {
            CollectionViewQuiz.ItemsSource = await _quizService.GetAllQuizzesAsync();
        }
    }
}
