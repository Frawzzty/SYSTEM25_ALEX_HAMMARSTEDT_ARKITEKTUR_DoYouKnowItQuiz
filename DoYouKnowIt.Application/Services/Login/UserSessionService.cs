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
    public class UserSessionService : IUserSessionService
    {
        private UserSession _thisSession;

        //Singelton - The user only needs to login one time when using the application

        public UserSessionService()
        {
            _thisSession = UserSession.GetUserSession();
        }

        public UserSession GetSession()
        {
            return _thisSession;
        }

        public void SetSessionActive(string username, string password)
        {
            _thisSession.Username = username;
            _thisSession.Password = password;

            _thisSession.IsLoggedIn = true;
        }

        public void SetSessionInactive()
        {
            _thisSession.Username = "";
            _thisSession.Password = "";

            _thisSession.IsLoggedIn = false;
        }

    }
}
