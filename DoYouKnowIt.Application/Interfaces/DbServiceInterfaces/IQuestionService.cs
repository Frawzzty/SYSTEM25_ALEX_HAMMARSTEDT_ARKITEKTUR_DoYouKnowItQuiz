using Domain.Entities.Models.DbModels;

namespace DoYouKnowIt.Application.Interfaces.DbServiceInterfaces
{
    public interface IQuestionService
    {
        Task<Question?> GetQuestionAsync(int questionId);
        Task<List<Question>> GetAllQuestionAsync();

        Task CreateQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int questionId);
    }
}
