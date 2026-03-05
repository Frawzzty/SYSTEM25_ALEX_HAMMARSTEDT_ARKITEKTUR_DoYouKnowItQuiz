namespace DoYouKnowIt.Presentation.Controls;

public partial class QuizCardControl : ContentView
{
	public QuizCardControl()
	{
		InitializeComponent();
	}



    public static readonly BindableProperty QuizTitleProperty =
        BindableProperty.Create(
            nameof(QuizTitle),
            typeof(string),
            typeof(QuizCardControl),
            default(string));

    public string QuizTitle
    {
        get { return (string)GetValue(QuizTitleProperty); }
        set { SetValue(QuizTitleProperty, value); }

    }

    public static readonly BindableProperty QuizDescriptionProperty =
        BindableProperty.Create(
        nameof(QuizDescription),
        typeof(string),
        typeof(QuizCardControl),
        default(string));

    public string QuizDescription
    {
        get { return (string)GetValue(QuizDescriptionProperty); }
        set { SetValue(QuizDescriptionProperty, value); }

    }

    public static readonly BindableProperty QuizImageUrlProperty =
        BindableProperty.Create(
        nameof(QuizImageUrl),
        typeof(string),
        typeof(QuizCardControl),
        default(string));

    public string QuizImageUrl
    {
        get { return (string)GetValue(QuizImageUrlProperty); }
        set { SetValue(QuizImageUrlProperty, value); }

    }
}