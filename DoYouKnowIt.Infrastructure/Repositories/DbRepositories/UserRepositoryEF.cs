using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Infrastructure.Connections;
using Microsoft.EntityFrameworkCore;

namespace DoYouKnowIt.Infrastructure.Repositories.DbRepositories
{
    //Not optimal: Using "using" on each Db call. For resolving issue with overlapping calls when using the same context for multiple db calls / same object beeing tracked twice.
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
