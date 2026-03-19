using Domain.Entities.Models.LoginModels;
using DoYouKnowIt.Application.Interfaces.LoginInterfaces;

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
