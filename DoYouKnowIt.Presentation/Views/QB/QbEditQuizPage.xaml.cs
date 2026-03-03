using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuizPage : ContentPage
{
	public QBEditQuizPage(Quiz quiz)
	{
		InitializeComponent();
		BindingContext = new ViewModels.QBEditQuizPageViewModel(quiz);
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        
        if(BindingContext is ViewModels.QBEditQuizPageViewModel vm)
        {
            await vm.UpdateQuestionList();
        }
    }
}