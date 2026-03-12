using Domain.Entities.Models.DbModels;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Interfaces.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Services.Login
{
    public class AuthenticationService : IAuthenticationService
    {
        //check login is valid
        IUserService _userService;
        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> IsAuthenticatedAsync(string username, string password)
        {
            User user = await _userService.GetByLoginAsync(username, password);

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
