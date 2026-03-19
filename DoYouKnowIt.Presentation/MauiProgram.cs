using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Facades;
using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;
using DoYouKnowIt.Application.Interfaces.LoginInterfaces;
using DoYouKnowIt.Application.Services.ApiNinjasServices;
using DoYouKnowIt.Application.Services.DbServices;
using DoYouKnowIt.Application.Services.LoginServices;
using DoYouKnowIt.Infrastructure.Connections;
using DoYouKnowIt.Infrastructure.Repositories.DbRepositories;
using DoYouKnowIt.Presentation.ViewModels;
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

            //Login facade components
            builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<ILoginFacade, LoginFacade>();

            //UserSession Singelton. Gets the same session on each page
            //builder.Services.AddSingleton<UserSession>();
            builder.Services.AddScoped<IUserSessionService, UserSessionService>();

            //MongoDB
            builder.Services.AddScoped<MongoDbConnection>();

            //Specific repos
            builder.Services.AddScoped<IQuizRepository, QuizRepositoryEF>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepositoryEF>();
            builder.Services.AddScoped<IAnswerRepository, AnswerRepositoryEF>();
            builder.Services.AddScoped<IUserRepository, UserRepositoryEF>();
            //Specific Services
            builder.Services.AddScoped<IQuizService, QuizService>();
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<IAnswerService, AnswerService>();
            builder.Services.AddScoped<IUserService, UserService>();


            //Generics Repos //Works but does not .include and .theninclude navigation props
            builder.Services.AddScoped<IRepository<Quiz>, RepositoryEF<Quiz>>();
            builder.Services.AddScoped<IRepository<Question>, RepositoryEF<Question>>();
            builder.Services.AddScoped<IRepository<Answer>, RepositoryEF<Answer>>();
            builder.Services.AddScoped<IRepository<User>, RepositoryEF<User>>();
            //Generics Services
            builder.Services.AddScoped<IRepositoryService<Quiz>, RepositoryService<Quiz>>();
            builder.Services.AddScoped<IRepositoryService<Question>, RepositoryService<Question>>();
            builder.Services.AddScoped<IRepositoryService<Answer>, RepositoryService<Answer>>();
            builder.Services.AddScoped<IRepositoryService<User>, RepositoryService<User>>();


            //Main page (View & ViewModels)
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();

            //Pages: QuizBuilder (Views & ViewModels)
            builder.Services.AddTransient<QBSelectPage>();
            builder.Services.AddTransient<QBSelectPageViewModel>();

            builder.Services.AddTransient<QBEditQuizPage>();
            builder.Services.AddTransient<QBEditQuizPageViewModel>();

            builder.Services.AddTransient<QBEditQuestionPage>();
            builder.Services.AddTransient<QBEditQuestionPageViewModel>();

            builder.Services.AddTransient<QBEditAnswerPage>();
            builder.Services.AddTransient<QBEditAnswerPageViewModel>();

            //Pages: PlayQuiz (Views & ViewModels)
            builder.Services.AddTransient<PlaySelectQuizPage>();
            builder.Services.AddTransient<PlaySelectQuizPageViewModel>();

            builder.Services.AddTransient<PlayPlayQuizPage>();
            builder.Services.AddTransient<PlayPlayQuizPageViewModel>();


            //API Ninjas 
            builder.Services.AddScoped<ApiNinjasDataManager>();
            builder.Services.AddScoped<ApiNinjasCountryService>();
            return builder.Build();
        }
    }
}
