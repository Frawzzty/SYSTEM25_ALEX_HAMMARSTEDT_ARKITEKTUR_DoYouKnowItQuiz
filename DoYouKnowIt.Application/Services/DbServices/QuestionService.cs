using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;

namespace DoYouKnowIt.Application.Services.DbServices
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionService(IQuestionRepository qustionRepo)
        {
            _questionRepo = qustionRepo;
        }

        public async Task<Question?> GetQuestionAsync(int questionId)
            => await _questionRepo.GetByIdAsync(questionId);
        public async Task<List<Question>> GetAllQuestionAsync()
            => await _questionRepo.GetAllAsync();


        public async Task CreateQuestionAsync(Question question)
        {
            await _questionRepo.AddAsync(question);
        }
        public async Task UpdateQuestionAsync(Question question)
        {
            await _questionRepo.UpdateAsync(question);
        }

        public async Task DeleteQuestionAsync(int questionId)
        {
            await _questionRepo.DeleteAsync(questionId);
        }



    }
}
