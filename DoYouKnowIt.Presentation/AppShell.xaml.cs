namespace DoYouKnowIt.Presentation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //TEST PAGES
            Routing.RegisterRoute(nameof(Views.Test.QueryPropTestPage), typeof(Views.Test.QueryPropTestPage));

            //QUIZ BUILDER
            Routing.RegisterRoute(nameof(Views.QB.QBSelectPage), typeof(Views.QB.QBSelectPage));
            Routing.RegisterRoute(nameof(Views.QB.QBEditQuizPage), typeof(Views.QB.QBEditQuizPage));
            Routing.RegisterRoute(nameof(Views.QB.QBEditQuestionPage), typeof(Views.QB.QBEditQuestionPage));
            Routing.RegisterRoute(nameof(Views.QB.QBEditAnswerPage), typeof(Views.QB.QBEditAnswerPage));

            //QUIZ PLAY
            Routing.RegisterRoute(nameof(Views.Play.PlaySelectQuizPage), typeof(Views.Play.PlaySelectQuizPage));
            //Routing.RegisterRoute(nameof(Views.Play.PlaySelectQuizPage), typeof(Views.Play.PlaySelectQuizPage));


            //CountryFlag lookpup
            Routing.RegisterRoute(nameof(Views.ApiNInjas.CountrFlagLookupPage), typeof(Views.ApiNInjas.CountrFlagLookupPage));
        }
    }
}
