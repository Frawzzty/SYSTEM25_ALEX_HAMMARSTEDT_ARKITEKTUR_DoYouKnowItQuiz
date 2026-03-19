using Domain.Entities.Models.Login;
using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;
using DoYouKnowIt.Application.Interfaces.LoginInterfaces;

namespace DoYouKnowIt.Application.Services.LoginServices
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
