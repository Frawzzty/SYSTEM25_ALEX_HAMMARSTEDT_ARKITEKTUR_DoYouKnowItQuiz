namespace DoYouKnowIt.Application.Interfaces.DbServiceInterfaces
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
