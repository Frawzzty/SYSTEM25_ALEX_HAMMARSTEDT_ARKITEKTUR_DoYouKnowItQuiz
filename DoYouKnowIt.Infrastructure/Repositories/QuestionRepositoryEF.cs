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
    public class QuestionRepositoryEF : IQuestionRepository
    {
        private readonly MyDbContext _context = new MyDbContext();


        public async Task<Question?> GetByIdAsync(int questionId) 
            => await _context.Questions.Where(x => x.Id == questionId).Include(x => x.Answers).SingleOrDefaultAsync();
        public async Task<List<Question>> GetAllAsync() 
            => await _context.Questions.Include(x => x.Answers).ToListAsync();



        public async Task AddAsync(Question question)
        {
            if(question != null)
            {
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(Question question)
        {
            if (question != null)
            {
                _context.Update(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int questionId)
        {
            var question = _context.Questions.FirstOrDefaultAsync(x => x.Id == questionId);
            if (question != null)
            {
                _context.Remove(question);
                await _context.SaveChangesAsync();
            }
        }
    }
}
