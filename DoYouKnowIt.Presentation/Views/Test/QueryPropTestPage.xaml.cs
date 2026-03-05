
using DoYouKnowIt.Presentation.ViewModels.Test;
using System.Threading.Tasks;

namespace DoYouKnowIt.Presentation.Views.Test;

public partial class QueryPropTestPage : ContentPage, IQueryAttributable
{

	public QueryPropTestPage(QueryPropTestPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }

	//Set ID in viewmodel
	public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		if (BindingContext is QueryPropTestPageViewModel vm &&
			query.TryGetValue("quizId", out var idParam))
		{
			if(int.TryParse(idParam.ToString(), out int id))
			{
                vm.QuizId = id;
            }
			
			vm.LoadQuiz();
		}
    }

}