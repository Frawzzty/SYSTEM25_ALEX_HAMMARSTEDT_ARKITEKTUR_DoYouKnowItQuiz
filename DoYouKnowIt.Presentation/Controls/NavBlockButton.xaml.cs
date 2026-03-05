using System.Windows.Input;

namespace DoYouKnowIt.Presentation.Controls;

public partial class NavBlockButton : ContentView
{
    public NavBlockButton()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty ButtonTextProperty =
        BindableProperty.Create(
            nameof(ButtonText),
            typeof(string),
            typeof(NavBlockButton));


    public string ButtonText
    {
        get { return (string)GetValue(ButtonTextProperty); }
        set { SetValue(ButtonTextProperty, value); }
    }


    public static readonly BindableProperty ButtonCommandProperty =
        BindableProperty.Create(
            nameof(ButtonCommand),
            typeof(ICommand),
            typeof(NavBlockButton));

    public ICommand ButtonCommand
    {
        get { return (ICommand)GetValue(ButtonCommandProperty); }
        set { SetValue(ButtonCommandProperty, value); }
    }

    private async void OnButtonPressed(object sender, EventArgs e)
    {
        MyObject.Opacity = 0.5;
    }

    private async void OnButtonReleased(object sender, EventArgs e)
    {
        MyObject.Opacity = 1;
    }
}