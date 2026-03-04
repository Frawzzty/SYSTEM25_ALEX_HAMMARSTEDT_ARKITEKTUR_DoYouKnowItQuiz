using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditAnswerPage : ContentPage
{
	public QBEditAnswerPage(int questionId, Answer answer)
	{
		InitializeComponent();
		BindingContext = new ViewModels.QB.QBEditAnswerPageViewModel(questionId, answer);
	}
}