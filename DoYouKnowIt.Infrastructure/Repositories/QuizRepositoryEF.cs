using Domain.Entities.Interfaces;
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Infrastructure.Repositories
{
    public class QuizRepositoryEF : IQuizRepository
    {
        private readonly MyDbContext _context = new MyDbContext();

        public async Task<Quiz?> GetByIdAsync(int quizId) 
            => await _context.Quizzes.Where(x => x.Id == quizId).Include(x => x.Questions).ThenInclude(x => x.Answers).AsNoTracking().SingleOrDefaultAsync();
        

        public async Task<List<Quiz>> GetAllAsync() 
            => await _context.Quizzes.Include(x => x.Questions).ThenInclude(x => x.Answers).AsNoTracking().ToListAsync();
       


        public async Task AddAsync(Quiz quiz)
        {
            if (quiz != null)
            {
                await _context.Quizzes.AddAsync(quiz);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Quiz quiz)
        {
            if (quiz != null)
            {
                _context.Update(quiz);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int quizId)
        {
            var quiz = await _context.Quizzes.FirstOrDefaultAsync(x => x.Id == quizId);
            if (quiz != null)
            {
                _context.Remove(quiz);
                await _context.SaveChangesAsync();
            }
        }


    }
}
