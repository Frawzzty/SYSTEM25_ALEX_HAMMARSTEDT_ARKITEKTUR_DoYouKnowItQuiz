using Domain.Entities.Interfaces;
using Domain.Entities.Models.EntityFrameworkModels;
using DoYouKnowIt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Infrastructure.Repositories
{
    public class AnswerRepositoryEF : IAnswerRepository
    {
        private readonly MyDbContext _context = new MyDbContext();

        public async Task<Answer?> GetByIdAsync(int answerId)
            => await _context.Answers.Where(x => x.Id == answerId).SingleOrDefaultAsync();
        public async Task<List<Answer>> GetAllAsync()
            => await _context.Answers.ToListAsync();



        public async Task AddAsync(Answer answer)
        {
            if(answer != null)
            {
                await _context.Answers.AddAsync(answer);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Answer answer)
        {
            if (answer != null)
            {
                _context.Update(answer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int answerId)
        {
            var answer = await _context.Questions.FirstOrDefaultAsync(x => x.Id == answerId);
            if (answer != null)
            {
                _context.Remove(answer);
                await _context.SaveChangesAsync();
            }
        }

    }
}
