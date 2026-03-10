using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Infrastructure.Repositories
{
    //Not optimal: Using "using" on each Db call to resolve issue with overlapping calls / same object beeing tracked twice.
    public class QuestionRepositoryEF : IQuestionRepository
    {

        public async Task<Question?> GetByIdAsync(int questionId)
        {
            using (var context = new MyDbContext())
            {
                return await context.Questions.Where(x => x.Id == questionId).Include(x => x.Answers).SingleOrDefaultAsync();
            }
        }
        public async Task<List<Question>> GetAllAsync()
        {
            using (var context = new MyDbContext()) 
            {
                return await context.Questions.Include(x => x.Answers).ToListAsync();
            }
        }

        public async Task AddAsync(Question question)
        {
            if(question != null)
            {
                using (var context = new MyDbContext())
                {
                    await context.Questions.AddAsync(question);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task UpdateAsync(Question question)
        {
            if (question != null)
            {
                using (var context = new MyDbContext()) 
                {
                    context.Update(question);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task DeleteAsync(int questionId)
        {
            using (var context = new MyDbContext())
            {
                var question = await context.Questions.FirstOrDefaultAsync(x => x.Id == questionId);
                if (question != null)
                {
                    context.Remove(question);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
