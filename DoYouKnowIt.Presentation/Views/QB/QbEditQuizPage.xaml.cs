namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuizPage : ContentPage
{
	public QBEditQuizPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.QBEditQuizPageViewModel();
	}
}