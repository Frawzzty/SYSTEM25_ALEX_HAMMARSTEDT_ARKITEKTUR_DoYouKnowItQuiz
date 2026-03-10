using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuizPage : ContentPage, IQueryAttributable
{
	public QBEditQuizPage(ViewModels.QB.QBEditQuizPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        //Get ID from GoToAsync Query Property
        if (BindingContext is ViewModels.QB.QBEditQuizPageViewModel vm)
        {
            if (query.TryGetValue("QuizId", out var idParam))
            {
                if (int.TryParse(idParam.ToString(), out int id))
                {
                    vm.QuizId = id;
                }
            }

            await vm.LoadData();
            vm.IsInitialized = true;
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        
        if(BindingContext is ViewModels.QB.QBEditQuizPageViewModel vm)
        {
            if (vm.IsInitialized)
                await vm.LoadData();
        }
    }
}