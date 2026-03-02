using Domain.Entities.Interfaces;
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Services
{
    public class QuestionService : IQuestionService
    {
        IQuestionRepository _questionRepo = new QuestionRepositoryEF();

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
