using Domain.Entities.Enums;
using Domain.Entities.Models.Login;
using DoYouKnowIt.Application.Interfaces.LoginInterfaces;

namespace DoYouKnowIt.Application.Facades
{
    public class LoginFacade : ILoginFacade
    {
        private readonly IAuthenticationService _autherizationService;
        private readonly IAuthorizationService _authenticationService;
        private IUserSessionService _userSessionService;

        public LoginFacade(IAuthenticationService autherizationService, IAuthorizationService authenticationService, IUserSessionService userSessionService)
        {
            _autherizationService = autherizationService;
            _authenticationService = authenticationService;
            _userSessionService = userSessionService;
        }

        public async Task<bool> UserIsAdminAsync()
        {
            UserSession session = _userSessionService.GetSession();

            if (await _autherizationService.IsAuthenticatedAsync(session.Username, session.Password) &&
                await _authenticationService.IsAuthorizedAsync(UserRole.Admin.ToString()))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UserLogin(string username, string password)
        {
            if (await _autherizationService.IsAuthenticatedAsync(username, password))
            {
                _userSessionService.SetSessionActive(username, password);
                return true;
            }

            return false;
        }

        public async Task<bool> UserIsLoggedIn()
        {
            if (!_userSessionService.GetSession().IsLoggedIn)
                return true;
            else 
                return false;
        }

        public void UserLogout()
        {
            _userSessionService.SetSessionInactive();
        }
    }
}
