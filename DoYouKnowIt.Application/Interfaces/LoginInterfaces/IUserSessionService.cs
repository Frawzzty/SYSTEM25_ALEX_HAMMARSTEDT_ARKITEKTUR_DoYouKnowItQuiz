using Domain.Entities.Models.LoginModels;

namespace DoYouKnowIt.Application.Interfaces.LoginInterfaces
{
    public interface IUserSessionService
    {

        public UserSession GetSession();
        public void SetSessionActive(string username, string password);

        public void SetSessionInactive();
    }
}
