using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Services
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class
    {
        IRepository<T> _repo = new RepositoryEF<T>();

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetOneAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
