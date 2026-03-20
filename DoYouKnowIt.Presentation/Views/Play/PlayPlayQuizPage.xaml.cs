using DoYouKnowIt.Presentation.ViewModels.Play;

namespace DoYouKnowIt.Presentation.Views.Play;

public partial class PlayPlayQuizPage : ContentPage, IQueryAttributable
{
	public PlayPlayQuizPage(PlayPlayQuizPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

	}

    //Set Query Properties values in the ViewModel
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is not PlayPlayQuizPageViewModel vm)
            return;

        //Get Query Properties
        if (query.TryGetValue("QuizId", out var quizIdString))
        {
            //Parse Query Properties
            if (int.TryParse(quizIdString.ToString(), out int quizId))
            {
                vm.QuizId = quizId;
            }
        }

        //Load data
        await vm.LoadDataAsync();
    }
}