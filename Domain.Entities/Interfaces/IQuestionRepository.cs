using Domain.Entities.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question?> GetByIdAsync(int questionId);

        Task<List<Question>> GetAllAsync();

        Task AddAsync(Question question);

        Task UpdateAsync(Question question);

        Task DeleteAsync(int questionId);
    }
}
