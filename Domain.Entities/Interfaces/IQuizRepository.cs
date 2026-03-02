using Domain.Entities.Models.EntityFrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IQuizRepository
    {
        Task<Quiz?> GetByIdAsync(int quizId);

        Task<List<Quiz>> GetAllAsync();

        Task AddAsync(Quiz quiz);

        Task UpdateAsync(Quiz quiz);

        Task DeleteAsync(int quizId);
    }
}
