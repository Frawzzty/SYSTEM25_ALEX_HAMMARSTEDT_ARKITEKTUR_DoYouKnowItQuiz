using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Services;
using DoYouKnowIt.Presentation.ViewModels.QB;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBSelectPage : ContentPage
{
	public QBSelectPage(QBSelectPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
		if(BindingContext is ViewModels.QB.QBSelectPageViewModel vm)
		{
			await vm.LoadData();
		}
    }

    private async void OnClickAddNewQuiz(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(Views.QB.QBEditQuizPage)}"); //Send no Quiz ID parameter
    }
}