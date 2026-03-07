using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuestionPage : ContentPage, IQueryAttributable
{
	public QBEditQuestionPage(ViewModels.QB.QBEditQuestionPageViewModel vm)
	{
        //old ctor params int quizId ,Question question
        InitializeComponent();
		BindingContext = vm;


	}


    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        //Get ID from GoToAsync Query Property
        if (BindingContext is ViewModels.QB.QBEditQuestionPageViewModel vm)
        {
            if (query.TryGetValue("QuizId", out var idQuizString) && query.TryGetValue("QuestionId", out var idQuestionString))
            {
                if (int.TryParse(idQuizString.ToString(), out int quizId) && int.TryParse(idQuestionString.ToString(), out int questionId)) 
                {
                    vm.QuizId = quizId;
                    vm.QuestionId = questionId;
                }
            }

            await vm.InitializeData();
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if(BindingContext is ViewModels.QB.QBEditQuestionPageViewModel vm)
        {
            //vm.RefreshQuestionList();
        }
    }
}