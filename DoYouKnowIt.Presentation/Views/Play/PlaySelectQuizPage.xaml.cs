namespace DoYouKnowIt.Presentation.Views.Play;

public partial class PlaySelectQuizPage : ContentPage
{
	public PlaySelectQuizPage(ViewModels.Play.PlaySelectQuizPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}