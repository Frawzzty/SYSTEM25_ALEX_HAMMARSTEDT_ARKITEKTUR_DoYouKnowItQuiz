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

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        btnBack.Opacity = 0.8;
    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        btnBack.Opacity = 1;
    }
}