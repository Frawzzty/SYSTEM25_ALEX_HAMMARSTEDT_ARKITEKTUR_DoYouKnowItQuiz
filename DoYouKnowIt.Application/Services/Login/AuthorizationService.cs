using Domain.Entities.Models;
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
        UserSession _userSession;
        public AuthorizationService(IUserService userService)
        {
            _userService = userService;
            _userSession = UserSession.GetUserSession();
        }
        public async Task<bool> IsAuthorizedAsync(string role)
        {
            var user = await _userService.GetByLoginAsync(_userSession.Username, _userSession.Password);

            if (user == null) 
                return false;

            if (user.Role == role) 
                return true;

            return false;
        }
    }
}
