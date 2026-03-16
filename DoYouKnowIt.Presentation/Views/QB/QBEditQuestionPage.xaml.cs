using Domain.Entities.Models.DbModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuestionPage : ContentPage, IQueryAttributable
{
	public QBEditQuestionPage(ViewModels.QB.QBEditQuestionPageViewModel vm)
	{
        InitializeComponent();
		BindingContext = vm;
	}

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        //Get ID from GoToAsync Query Property
        if (BindingContext is ViewModels.QB.QBEditQuestionPageViewModel vm)
        {
            //Get query properties
            if (query.TryGetValue("QuizId", out var idQuizString) && query.TryGetValue("QuestionId", out var idQuestionString))
            {
                //Parse query properties
                if (int.TryParse(idQuizString.ToString(), out int quizId) && int.TryParse(idQuestionString.ToString(), out int questionId)) 
                {
                    vm.QuizId = quizId;
                    vm.QuestionId = questionId;
                }
            }

            //Load data
            await vm.LoadData();
            vm.IsInitialized = true;
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        //Only load on appearing if been loaded once. (If page ahead uses Navigation.pop())
        if (BindingContext is ViewModels.QB.QBEditQuestionPageViewModel vm)
        {
            if(vm.IsInitialized)
                await vm.LoadData();
        }
    }
}