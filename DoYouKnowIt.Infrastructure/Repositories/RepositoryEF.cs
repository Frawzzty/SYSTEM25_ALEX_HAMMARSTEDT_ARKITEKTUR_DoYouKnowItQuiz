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
    //Unused
    public class RepositoryEF<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _context = new MyDbContext();

        public async Task<T?> GetByIdAsync(int entityId) 
            => await _context.Set<T>().FindAsync(entityId);
        public async Task<List<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();


        public async Task AddAsync(T entity)
        {
            if (entity != null)
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            var entity = await _context.Set<T>().FindAsync(entityId);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
