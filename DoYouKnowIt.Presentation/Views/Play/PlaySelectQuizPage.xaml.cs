using DoYouKnowIt.Presentation.ViewModels.Play;

namespace DoYouKnowIt.Presentation.Views.Play;

public partial class PlaySelectQuizPage : ContentPage
{
	public PlaySelectQuizPage(PlaySelectQuizPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

		if(BindingContext is PlaySelectQuizPageViewModel vm)
		{
			await vm.LoadQuizzes();
		}
    }
}