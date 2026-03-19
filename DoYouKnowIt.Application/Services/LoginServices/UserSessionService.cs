using Domain.Entities.Models.Login;
using DoYouKnowIt.Application.Interfaces;
using DoYouKnowIt.Application.Interfaces.LoginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Services.LoginServices
{
    public class UserSessionService : IUserSessionService
    {
        private UserSession _thisSession;

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
            _thisSession.SetSessionActive(username, password);
        }

        public void SetSessionInactive()
        {
            _thisSession.SetSessionInactive();
        }
    }
}
