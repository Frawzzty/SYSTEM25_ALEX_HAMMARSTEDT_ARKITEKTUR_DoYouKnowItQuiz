using Domain.Entities.Models.DbModels;

namespace Domain.Entities.Interfaces
{
    public interface IQuizRepository
    {
        Task<Quiz?> GetByIdAsync(int quizId);

        Task<List<Quiz>> GetAllAsync();

        Task AddAsync(Quiz quiz);

        Task UpdateAsync(Quiz quiz);

        Task DeleteAsync(int quizId);
    }
}
