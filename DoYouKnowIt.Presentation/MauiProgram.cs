using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using Domain.Entities.Models.Game;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using DoYouKnowIt.Application.Services.ApiNinjas;
using DoYouKnowIt.Infrastructure.Data;
using DoYouKnowIt.Infrastructure.Repositories;
using DoYouKnowIt.Presentation.ViewModels.Play;
using DoYouKnowIt.Presentation.ViewModels.QB;
using DoYouKnowIt.Presentation.Views.Play;
using DoYouKnowIt.Presentation.Views.QB;
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

            //Generics Repos
            builder.Services.AddScoped<IRepository<Quiz>, RepositoryEF<Quiz>>();
            builder.Services.AddScoped<IRepository<Question>, RepositoryEF<Question>>();
            builder.Services.AddScoped<IRepository<Answer>, RepositoryEF<Answer>>();

            //Generics Services
            builder.Services.AddScoped<IRepositoryService<Quiz>, RepositoryService<Quiz>>();
            builder.Services.AddScoped<IRepositoryService<Question>, RepositoryService<Question>>();
            builder.Services.AddScoped<IRepositoryService<Answer>, RepositoryService<Answer>>();

            //QuizBuilder Views & ViewModels
            builder.Services.AddTransient<QBSelectPage>();
            builder.Services.AddTransient<QBSelectPageViewModel>();

            builder.Services.AddTransient<QBEditQuizPage>();
            builder.Services.AddTransient<QBEditQuizPageViewModel>();

            builder.Services.AddTransient<QBEditQuestionPage>();
            builder.Services.AddTransient<QBEditQuestionPageViewModel>();

            builder.Services.AddTransient<QBEditAnswerPage>();
            builder.Services.AddTransient<QBEditAnswerPageViewModel>();

            //PlayQuiz pages
            builder.Services.AddTransient<PlaySelectQuizPage>();
            builder.Services.AddTransient<PlaySelectQuizPageViewModel>();

            builder.Services.AddTransient<PlayPlayQuizPage>();
            builder.Services.AddTransient<PlayPlayQuizPageViewModel>();

            

            //API Ninjas 
            builder.Services.AddTransient<ApiNinjasDataManager>();
            builder.Services.AddTransient<ApiNinjasCountryService>();
            return builder.Build();
        }
    }
}
