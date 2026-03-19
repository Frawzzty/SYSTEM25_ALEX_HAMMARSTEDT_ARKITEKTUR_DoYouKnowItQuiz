using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Infrastructure.Connections;
using Microsoft.EntityFrameworkCore;

namespace DoYouKnowIt.Infrastructure.Repositories.DbRepositories
{
    public class UserRepositoryEF : IUserRepository
    {
        public async Task<User?> GetByLoginAsync(string username, string password)
        {
            using (var context = new MyDbContext())
            {
                //check username in lower, password casesensitive
                return await context.Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).SingleOrDefaultAsync();
            }
        }
    }
}
