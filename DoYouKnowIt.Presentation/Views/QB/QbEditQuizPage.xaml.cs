using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuizPage : ContentPage
{
	public QBEditQuizPage(Quiz quiz)
	{
		InitializeComponent();
		BindingContext = new ViewModels.QB.QBEditQuizPageViewModel(quiz);
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        
        if(BindingContext is ViewModels.QB.QBEditQuizPageViewModel vm)
        {
            await vm.RefreshQuestionList();
        }
    }
}