using Domain.Entities.Models.DbModels;

namespace Domain.Entities.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer?> GetByIdAsync(int answerId);

        Task<List<Answer>> GetAllAsync();

        Task AddAsync(Answer answer);

        Task UpdateAsync(Answer answer);

        Task DeleteAsync(int answerId);
    }
}
