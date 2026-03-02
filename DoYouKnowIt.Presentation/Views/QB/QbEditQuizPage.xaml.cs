using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuizPage : ContentPage
{
	public QBEditQuizPage(Quiz quiz)
	{
		InitializeComponent();
		BindingContext = new ViewModels.QBEditQuizPageViewModel(quiz);
	}

    private async void OnClickSaveQuiz(object sender, EventArgs e)
    {
		if(BindingContext is ViewModels.QBEditQuizPageViewModel vm)
		{
			await vm.SaveQuizAsync();
			await Navigation.PopAsync();
		}
    }
}