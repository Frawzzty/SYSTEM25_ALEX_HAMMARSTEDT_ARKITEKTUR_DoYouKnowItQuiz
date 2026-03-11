using System.ComponentModel;
using System.Windows.Input;

namespace DoYouKnowIt.Presentation.Controls;

public partial class QuizResultCard : ContentView
{
	public QuizResultCard()
	{
		InitializeComponent();
    }

    private void OnLoadedQuizResultCard(Object sender, EventArgs e)
    {
        SetBackgroundBackground();
    }

    private void SetBackgroundBackground()
    {
        //Green
        if (IsCorrect)
        {
            QuizResultCardBox.Background = new LinearGradientBrush(
                new GradientStopCollection
                {
                    new GradientStop(new Color(0,120,50), 0.0f),
                    new GradientStop(new Color(0,200,0), 1.0f)
                },
                new Point(0, 0),
                new Point(1, 1)
                );
        }
        //Red
        else
        {
            QuizResultCardBox.Background = new LinearGradientBrush(
                new GradientStopCollection
                {
                new GradientStop(new Color(140,0,50), 0.0f),
                new GradientStop(new Color(220,0,0), 1.0f)
                },
                new Point(0, 0),
                new Point(1, 1)
                );
        }

    }


    //Bindable Properties
    //QuestionText
    public static readonly BindableProperty QuestionTextProperty =
       BindableProperty.Create(
           nameof(QuestionText),
           typeof(string),
           typeof(QuizResultCard),
           default(string)
           );
    public string QuestionText
    {
        get { return (string)GetValue(QuestionTextProperty); }
        set { SetValue(QuestionTextProperty, value); }
    }

    //CorrectAnswerText
    public static readonly BindableProperty CorrectAnswersTextProperty =
        BindableProperty.Create(
           nameof(CorrectAnswersText),
           typeof(string),
           typeof(QuizResultCard),
           default(string)
            );
    public string CorrectAnswersText
    {
        get { return (string)GetValue(CorrectAnswersTextProperty); }
        set { SetValue(CorrectAnswersTextProperty, value); }
    }

    //SelectedAnswerText
    public static readonly BindableProperty SelectedAnswerTextProperty =
        BindableProperty.Create(
            nameof(SelectedAnswerText),
            typeof(string),
            typeof(QuizResultCard),
            default(string)
            );
    public string SelectedAnswerText
    {
        get { return (string)GetValue(SelectedAnswerTextProperty); }
        set { SetValue(SelectedAnswerTextProperty, value); }
    }

    //IsCorrect
    public static readonly BindableProperty IsCorrectProperty =
        BindableProperty.Create(
            nameof(IsCorrect),
            typeof(bool),
            typeof(QuizResultCard),
            default(bool)
            );

    public bool IsCorrect
    {
        get {return (bool)GetValue(IsCorrectProperty);}
        set {SetValue(IsCorrectProperty, value);
        }
    }

    //RoundScore
    public static readonly BindableProperty RoundScoreProperty =
        BindableProperty.Create(
            nameof(RoundScore),
            typeof(int),
            typeof(QuizResultCard),
            default(int)
            );
    public int RoundScore
    {
        get { return (int)GetValue(RoundScoreProperty); }
        set { SetValue(RoundScoreProperty, value); }
    }


}