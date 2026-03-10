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
    public class AnswerRepositoryEF : IAnswerRepository
    {
        public async Task<Answer?> GetByIdAsync(int answerId)
        {
            using (var context = new MyDbContext())
            {
                return await context.Answers.Where(x => x.Id == answerId).SingleOrDefaultAsync();
            }
        }
        public async Task<List<Answer>> GetAllAsync() 
        {
            using (var context = new MyDbContext())
            {
                return await context.Answers.ToListAsync();
            }
        }

        public async Task AddAsync(Answer answer)
        {
            if(answer != null)
            {
                using (var context = new MyDbContext()) 
                {
                    await context.Answers.AddAsync(answer);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task UpdateAsync(Answer answer)
        {
            if (answer != null)
            {
                using (var context = new MyDbContext())
                {
                    context.Update(answer);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task DeleteAsync(int answerId)
        {
            using (var context = new MyDbContext()) 
            {
                var answer = await context.Answers.FirstOrDefaultAsync(x => x.Id == answerId);
                if (answer != null)
                {
                    context.Remove(answer);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
