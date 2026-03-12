using Domain.Entities.Models;
using DoYouKnowIt.Application.Interfaces.NewFolder;

namespace DoYouKnowIt.Application.Facades
{
    public class LoginFacade : ILoginFacade
    {
        private readonly IAuthenticationService _autherizationService;
        private readonly IAuthorizationService _authenticationService;
        private UserSession _userSession;

        public LoginFacade(IAuthenticationService autherizationService, IAuthorizationService authenticationService, UserSession userSession)
        {
            _autherizationService = autherizationService;
            _authenticationService = authenticationService;
            _userSession = userSession;
        }

        public async Task<bool> UserIsAdminAsync(string username, string password)
        {
            if (await _autherizationService.IsAuthenticatedAsync(username, password) &&
                await _authenticationService.IsAuthorizedAsync(username, password, "Admin")) //Make enum? //Double db call
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UserLogin(string username, string password)
        {
            if (await _autherizationService.IsAuthenticatedAsync(username, password))
            {
                _userSession.SetSessionActive(username, password);
                return true;
            }

            return false;

        }

        public void UserLogout()
        {
            _userSession.SetSessionInactive();
        }
    }
}
