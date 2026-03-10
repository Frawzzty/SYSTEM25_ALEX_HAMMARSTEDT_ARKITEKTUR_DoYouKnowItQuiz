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
        private readonly IRepository<T> _repo;

        public RepositoryService(IRepository<T> repo)
        {
            _repo = repo;
        }

        public Task<T?> GetOneAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }


    }
}
