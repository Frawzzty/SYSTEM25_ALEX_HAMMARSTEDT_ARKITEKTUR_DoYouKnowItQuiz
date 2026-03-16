using Domain.Entities.Models.Game;

namespace DoYouKnowIt.Presentation.Views.Play;

public partial class PlayResultQuizPage : ContentPage
{
	public PlayResultQuizPage(QuizResult quizResult) //Could make List<QuizRoundResult> instead?
	{
		InitializeComponent();
		BindingContext = new ViewModels.Play.PlayResultQuizPageViewModel(quizResult);
	}
}