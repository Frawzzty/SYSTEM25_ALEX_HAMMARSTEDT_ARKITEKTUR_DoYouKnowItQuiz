using DoYouKnowIt.Presentation.ViewModels.Play;

namespace DoYouKnowIt.Presentation.Views.Play;

public partial class PlaySelectQuizPage : ContentPage
{
	public PlaySelectQuizPage(PlaySelectQuizPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }

    bool isRunningAnimations = true;
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        //Load data
		if(BindingContext is PlaySelectQuizPageViewModel vm)
		{
			await vm.LoadQuizzes();
		}

        //Start animations on appearing
        isRunningAnimations = true;
        RunAnimations();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        //Will crash without this when navigation back to this page.
        isRunningAnimations = false;
        Microsoft.Maui.Controls.ViewExtensions.CancelAnimations(ImageTopQuizPlay);
    }

    private async void RunAnimations()
    {
        while (isRunningAnimations)
        {
            ImageTopQuizPlay.Scale = 1;
            await ImageTopQuizPlay.ScaleTo(1.1, 2000, Easing.CubicInOut);
            await ImageTopQuizPlay.ScaleTo(1, 2000);
            ImageTopQuizPlay.Scale = 1;
        }
    }

}