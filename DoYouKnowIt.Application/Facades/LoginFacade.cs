using Domain.Entities.Models;
using DoYouKnowIt.Application.Interfaces.NewFolder;
using DoYouKnowIt.Application.Services.Login;

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
            UserSession userSession = _userSessionService.GetSession();
            if (await _autherizationService.IsAuthenticatedAsync(userSession.Username, userSession.Password) &&
                await _authenticationService.IsAuthorizedAsync("Admin")) //Make enum? //Double db call
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
            UserSession userSession = _userSessionService.GetSession();

            if (!userSession.IsLoggedIn)
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
