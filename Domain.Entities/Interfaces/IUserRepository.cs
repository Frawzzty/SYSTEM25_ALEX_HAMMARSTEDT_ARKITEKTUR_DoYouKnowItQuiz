using Domain.Entities.Models.DbModels;

namespace Domain.Entities.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByLoginAsync(string username, string password);

    }
}
