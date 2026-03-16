using Domain.Entities.Models.DbModels;
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

}