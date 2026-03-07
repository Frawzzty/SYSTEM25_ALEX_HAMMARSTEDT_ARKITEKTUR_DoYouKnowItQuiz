using Domain.Entities.Interfaces;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using DoYouKnowIt.Application.Services.ApiNinjas;
using DoYouKnowIt.Infrastructure.Data;
using DoYouKnowIt.Infrastructure.Repositories;
using DoYouKnowIt.Presentation.ViewModels.Test;
using Microsoft.Extensions.Logging;

namespace DoYouKnowIt.Presentation
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            //Dependency Injection
            builder.Services.AddScoped<IQuizService, QuizService>();
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<IAnswerService, AnswerService>();

            builder.Services.AddScoped<IQuizRepository, QuizRepositoryEF>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepositoryEF>();
            builder.Services.AddScoped<IAnswerRepository, AnswerRepositoryEF>();


            
            builder.Services.AddTransient<QueryPropTestPageViewModel>();
            builder.Services.AddTransient<Views.Test.QueryPropTestPage>();

            //QuizBuilder Views & ViewModels
            builder.Services.AddTransient<Views.QB.QBSelectPage>();
            builder.Services.AddTransient<ViewModels.QB.QBSelectPageViewModel>();

            builder.Services.AddTransient<Views.QB.QBEditQuizPage>();
            builder.Services.AddTransient<ViewModels.QB.QBEditQuizPageViewModel>();

            builder.Services.AddTransient<Views.QB.QBEditQuestionPage>();
            builder.Services.AddTransient<ViewModels.QB.QBEditQuestionPageViewModel>();

            builder.Services.AddTransient<Views.QB.QBEditAnswerPage>();
            builder.Services.AddTransient<ViewModels.QB.QBEditAnswerPageViewModel>();

            //API Ninjas 
            builder.Services.AddTransient<ApiNinjasClient>();
            builder.Services.AddTransient<ApiNinjasCountryService>();
            return builder.Build();
        }
    }
}
