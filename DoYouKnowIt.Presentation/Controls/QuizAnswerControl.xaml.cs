namespace DoYouKnowIt.Presentation.Controls;

public partial class QuizAnswerControl : ContentView
{
	public QuizAnswerControl()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty QuizAnswerTextProperty =

    BindableProperty.Create(
        nameof(QuizAnswerText),
        typeof(string),
        typeof(QuizCardControl),
        default(string));

    public string QuizAnswerText
    {
        get { return (string)GetValue(QuizAnswerTextProperty); }
        set { SetValue(QuizAnswerTextProperty, value); }

    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        MyBorder.Opacity = 0.8;
    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        MyBorder.Opacity = 1;
    }

}