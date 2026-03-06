using Domain.Entities.Interfaces;
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Infrastructure.Data;
using DoYouKnowIt.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Services
{
    public class QuizService : IQuizService
    {
        
        IQuizRepository _quizRepo = new QuizRepositoryEF(new MyDbContext());

        public async Task<Quiz?> GetQuizAsync(int quizId) 
            => await _quizRepo.GetByIdAsync(quizId);
        public async Task<List<Quiz>> GetAllQuizzesAsync() 
            => await _quizRepo.GetAllAsync();
      

        public async Task CreateQuizAsync(Quiz quiz)
        {
            await _quizRepo.AddAsync(quiz);
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            await _quizRepo.UpdateAsync(quiz);
        }

        public async Task DeleteQuizAsync(int quizId)
        {
            await _quizRepo.DeleteAsync(quizId);
        }


    }
}
