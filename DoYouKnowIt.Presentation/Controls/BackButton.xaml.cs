namespace DoYouKnowIt.Presentation.Controls;

public partial class BackButton : ContentView
{
	public BackButton()
	{
		InitializeComponent();
	}

    private async void OnClickedGoBack(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}