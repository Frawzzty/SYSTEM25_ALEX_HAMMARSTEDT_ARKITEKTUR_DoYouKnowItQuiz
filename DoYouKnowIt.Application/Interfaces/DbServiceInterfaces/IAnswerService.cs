using Domain.Entities.Models.DbModels;

namespace DoYouKnowIt.Application.Interfaces.DbServiceInterfaces
{
    public interface IAnswerService
    {
        Task<Answer?> GetAnswerAsync(int answerId);
        Task<List<Answer>> GetAllAnswerAsync();

        Task CreateAnswernAsync(Answer answer);
        Task UpdateAnswerAsync(Answer answer);
        Task DeleteAnswerAsync(int answerId);
    }
}
