using Domain.Entities.Models.EntityFrameworkModels;

namespace DoYouKnowIt.Presentation.Views.QB;

public partial class QBEditQuestionPage : ContentPage
{
	public QBEditQuestionPage(int quizId, Question question)
	{
		InitializeComponent();
		BindingContext = new ViewModels.QBEditQuestionViewModel(quizId, question);
	}
}