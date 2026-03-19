using Domain.Entities.Models.DbModels;

namespace DoYouKnowIt.Application.Interfaces.DbServiceInterfaces
{
    public interface IQuizService
    {

        Task<Quiz?> GetQuizAsync(int quizId);
        Task<List<Quiz>> GetAllQuizzesAsync();

        Task CreateQuizAsync(Quiz quiz);
        Task UpdateQuizAsync(Quiz quiz);
        Task DeleteQuizAsync(int quizId);


    }
}
