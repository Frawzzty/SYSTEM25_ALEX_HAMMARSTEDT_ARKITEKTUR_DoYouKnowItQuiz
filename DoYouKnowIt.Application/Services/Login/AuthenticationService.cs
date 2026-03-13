using Domain.Entities.Models;
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
