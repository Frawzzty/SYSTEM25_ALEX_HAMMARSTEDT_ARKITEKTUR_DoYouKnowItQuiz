using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditAnswerPage : ContentPage, IQueryAttributable
{
	public QBEditAnswerPage(ViewModels.QB.QBEditAnswerPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}


    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        //Get ID from GoToAsync Query Property
        if (BindingContext is ViewModels.QB.QBEditAnswerPageViewModel vm)
        {
            if (query.TryGetValue("QuestionId", out var idQuestionString) && query.TryGetValue("AnswerId", out var idAnswerString))
            {
                if (int.TryParse(idQuestionString.ToString(), out int questionId) && int.TryParse(idAnswerString.ToString(), out int answerId))
                {
                    vm.QuestionId = questionId;
                    vm.AnswerId = answerId;
                }
            }

            await vm.InitializeData();
        }
    }
}