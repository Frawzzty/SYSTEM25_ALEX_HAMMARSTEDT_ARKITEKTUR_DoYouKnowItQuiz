using DoYouKnowIt.Presentation.ViewModels.Play;

namespace DoYouKnowIt.Presentation.Views.Play;

public partial class PlayPlayQuizPage : ContentPage
{
	public PlayPlayQuizPage(PlayPlayQuizPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

	}
}