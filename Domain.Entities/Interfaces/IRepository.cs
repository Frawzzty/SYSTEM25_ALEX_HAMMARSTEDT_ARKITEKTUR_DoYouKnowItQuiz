namespace Domain.Entities.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int entityId);

        Task<List<T>> GetAllAsync();


        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int entityId);
    }
}
