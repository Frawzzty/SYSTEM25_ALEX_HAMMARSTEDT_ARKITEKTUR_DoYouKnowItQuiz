using Domain.Entities.Models.DbModels;

namespace DoYouKnowIt.Application.Interfaces.DbServiceInterfaces
{
    public interface IUserService
    {
        Task<User?> GetByLoginAsync(string username, string password);
    }
}
