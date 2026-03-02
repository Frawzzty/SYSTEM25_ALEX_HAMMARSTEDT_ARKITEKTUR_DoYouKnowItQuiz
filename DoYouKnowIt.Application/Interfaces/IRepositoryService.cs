using Domain.Entities.Models.EntityFrameworkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces
{
    public interface IRepositoryService<T> where T : class
    {
        Task<T?> GetOneAsync(int entityId);
        Task<List<T>> GetAllAsync();

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int entityId);
    }
}
