using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuestionPage : ContentPage
{
	public QBEditQuestionPage(int quizId ,Question question)
	{
		InitializeComponent();
		BindingContext = new ViewModels.QB.QBEditQuestionPageViewModel(quizId, question);


	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if(BindingContext is ViewModels.QB.QBEditQuestionPageViewModel vm)
        {
            vm.RefreshQuestionList();
        }
    }
}