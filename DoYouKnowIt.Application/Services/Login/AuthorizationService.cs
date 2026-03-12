using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Interfaces.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Services.Login
{
    public class AuthorizationService : IAuthorizationService
    {
        //Check user permission
        IUserService _userService;
        public AuthorizationService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> IsAuthorizedAsync(string username, string password, string role)
        {
            var user = await _userService.GetByLoginAsync(username, role);

            if (user == null) return false;

            if (user.Role == role) return true;

            return false;
        }
    }
}
