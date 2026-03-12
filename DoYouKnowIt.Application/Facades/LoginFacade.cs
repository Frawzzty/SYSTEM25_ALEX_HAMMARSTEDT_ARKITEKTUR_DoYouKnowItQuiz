using DoYouKnowIt.Application.Interfaces.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Facades
{
    public class LoginFacade : ILoginFacade
    {
        private readonly IAuthenticationService _autherizationService;
        private readonly IAuthorizationService _authenticationService;

        public LoginFacade(IAuthenticationService autherizationService, IAuthorizationService authenticationService)
        {
            _autherizationService = autherizationService;
            _authenticationService = authenticationService;
        }

        public bool UserIsAdmin(string username, string password)
        {
            if (_autherizationService.IsAuthenticated(username, password) &&
                _authenticationService.IsAuthorized(username, password))
            {
                return true;
            }

            return false;

        }
    }
}
