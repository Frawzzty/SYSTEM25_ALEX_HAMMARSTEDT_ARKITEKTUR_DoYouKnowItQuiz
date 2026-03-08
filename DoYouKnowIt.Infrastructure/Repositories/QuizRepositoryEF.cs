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
    //Not optimal: Using "using" on each Db call to resolve issue with overlapping calls / same object beeing tracked twice.
    public class QuizRepositoryEF : IQuizRepository
    {
        public async Task<Quiz?> GetByIdAsync(int quizId)
        {
            using (var context = new MyDbContext())
            {
                return await context.Quizzes.Where(x => x.Id == quizId).Include(x => x.Questions).ThenInclude(x => x.Answers).SingleOrDefaultAsync();
            }
        }
          
        public async Task<List<Quiz>> GetAllAsync()
        {
            using (var context = new MyDbContext())
            {
                return await context.Quizzes.Include(x => x.Questions).ThenInclude(x => x.Answers).ToListAsync();
            }

        }

        public async Task AddAsync(Quiz quiz)
        {
            if (quiz != null)
            {
                using (var context = new MyDbContext()) 
                {
                    await context.Quizzes.AddAsync(quiz);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task UpdateAsync(Quiz quiz)
        {
            if (quiz == null)
                return;

            using (var context = new MyDbContext()) //Problems with Update same obj Since using its using the same dbContext
            {
                context.Update(quiz);
                await context.SaveChangesAsync();
            }

        }
        public async Task DeleteAsync(int quizId)
        {
            if (quizId == 0)
                return;

            using (var context = new MyDbContext())
            {
                var quiz = await context.Quizzes.FirstOrDefaultAsync(x => x.Id == quizId);

                if (quiz == null)
                    return;

                context.Remove(quiz);
                await context.SaveChangesAsync();

            }

        }
    }
}
