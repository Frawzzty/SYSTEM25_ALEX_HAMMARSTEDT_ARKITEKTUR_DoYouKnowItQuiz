using Domain.Entities.Models.Login;
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
        IUserSessionService _userSessionService;
        public AuthorizationService(IUserService userService, IUserSessionService userSessionService)
        {
            _userService = userService;
            _userSessionService = userSessionService;
        }
        public async Task<bool> IsAuthorizedAsync(string role)
        {
            UserSession session = _userSessionService.GetSession();

            var user = await _userService.GetByLoginAsync(session.Username, session.Password);

            if (user == null) 
                return false;

            if (user.Role == role) 
                return true;

            return false;
        }
    }
}
