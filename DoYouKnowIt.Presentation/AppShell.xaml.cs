namespace DoYouKnowIt.Presentation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.Test.QueryPropTestPage), typeof(Views.Test.QueryPropTestPage));
        }
    }
}
