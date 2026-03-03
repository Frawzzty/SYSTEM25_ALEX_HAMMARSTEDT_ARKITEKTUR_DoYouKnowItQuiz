using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Services;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBSelectPage : ContentPage
{
	public QBSelectPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.QBSelectPageViewModel();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
		if(BindingContext is ViewModels.QBSelectPageViewModel vm)
		{
			await vm.LoadData();
		}
    }

    private async void OnClickAddNewQuiz(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QBEditQuizPage(null));
    }
}