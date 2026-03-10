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

        public async Task<T?> GetOneAsync(int entityId)
            => await _repo.GetByIdAsync(entityId);

        public async Task<List<T>> GetAllAsync()
            => await _repo.GetAllAsync();

        public async Task CreateAsync(T entity)
        {
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int entityId)
        {
            await _repo.DeleteAsync(entityId);
        }


    }
}
