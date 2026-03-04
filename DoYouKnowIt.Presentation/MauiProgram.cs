using Domain.Entities.Interfaces;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using DoYouKnowIt.Infrastructure.Repositories;
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

            //builder.Services.AddTransient<QBEditQuizPage>();


            return builder.Build();
        }
    }
}
