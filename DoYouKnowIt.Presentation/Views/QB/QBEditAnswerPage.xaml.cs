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
            //Get query properties
            if (query.TryGetValue("QuestionId", out var idQuestionString) && query.TryGetValue("AnswerId", out var idAnswerString))
            {
                //Parse query properties
                if (int.TryParse(idQuestionString.ToString(), out int questionId) && int.TryParse(idAnswerString.ToString(), out int answerId))
                {
                    vm.QuestionId = questionId;
                    vm.AnswerId = answerId;
                }
            }

            //Load data
            await vm.LoadData();
            vm.IsInitialized = true;
        }
    }

    //Delete this method? Not needed since this page does not need to refresh?
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        //Only load on appearing if been loaded once. (If page ahead uses Navigation.pop())
        if (BindingContext is ViewModels.QB.QBEditAnswerPageViewModel vm)
        {
            if (vm.IsInitialized)
                await vm.LoadData();
        }
    }
}