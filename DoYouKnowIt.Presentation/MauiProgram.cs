using Domain.Entities.Interfaces;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Services;
using DoYouKnowIt.Infrastructure.Repositories;
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
            //builder.Services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>)); //Did not work



            return builder.Build();
        }
    }
}
