using Domain.Entities.Interfaces;
using DoYouKnowIt.Infrastructure.Connections;
using Microsoft.EntityFrameworkCore;

namespace DoYouKnowIt.Infrastructure.Repositories.DbRepositories
{
    //Not optimal: Using "using" on each Db call. For resolving issue with overlapping calls when using the same context for multiple db calls / same object beeing tracked twice.

    //Works, but cannot not include Navigation properties.
    public class RepositoryEF<T> : IRepository<T> where T : class
    {
        //Does not include navigation props due to being generic...
        public async Task<T?> GetByIdAsync(int entityId)
        {
            using (var context = new MyDbContext()) 
            {
                return await context.Set<T>().FindAsync(entityId);
            }
        }

        //Does not include navigation props due to being generic...
        public async Task<List<T>> GetAllAsync()
        {
            using (var context = new MyDbContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }


        public async Task AddAsync(T entity)
        {
            if (entity != null)
            {
                using (var context = new MyDbContext())
                {
                    await context.Set<T>().AddAsync(entity);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity != null)
            {
                using (var context = new MyDbContext())
                {
                    context.Set<T>().Update(entity);
                    await context.SaveChangesAsync();
                }
            }
        }
        public async Task DeleteAsync(int entityId)
        {
            using (var context = new MyDbContext())
            {
                var entity = await context.Set<T>().FindAsync(entityId);
                if (entity != null)
                {
                    context.Set<T>().Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
