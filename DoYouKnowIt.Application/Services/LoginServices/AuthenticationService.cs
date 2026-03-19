using DoYouKnowIt.Application.Interfaces.DbServiceInterfaces;
using DoYouKnowIt.Application.Interfaces.LoginInterfaces;

namespace DoYouKnowIt.Application.Services.LoginServices
{
    public class AuthenticationService : IAuthenticationService
    {
        //check login is valid
        IUserService _userService;
        IUserSessionService _userSessionService;
        public AuthenticationService(IUserService userService, IUserSessionService userSessionService)
        {
            _userService = userService;
            _userSessionService = userSessionService;
        }
        public async Task<bool> IsAuthenticatedAsync(string username, string password)
        {
            if (_userSessionService.GetSession().IsLoggedIn)
            {
                return true;
            }

            var user = await _userService.GetByLoginAsync(username, password);
            if (user != null)
            {
                _userSessionService.SetSessionActive(username, password);
                return true;
            }

            return false;
        }
    }
}
