using Domain.Entities.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer?> GetByIdAsync(int answerId);

        Task<List<Answer>> GetAllAsync();

        Task AddAsync(Answer answer);

        Task UpdateAsync(Answer answer);

        Task DeleteAsync(int answerId);
    }
}
