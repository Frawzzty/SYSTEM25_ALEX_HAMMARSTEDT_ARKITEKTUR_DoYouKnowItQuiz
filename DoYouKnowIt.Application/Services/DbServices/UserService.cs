using Domain.Entities.Interfaces;
using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;
using System.Diagnostics;

namespace DoYouKnowIt.Application.Services.DbServices
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByLoginAsync(string username, string password)
        {
            User user;
            try
            {
                user = await _userRepository.GetByLoginAsync(username, password);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                user = null;
            }
            return user;
        }
    }
}
