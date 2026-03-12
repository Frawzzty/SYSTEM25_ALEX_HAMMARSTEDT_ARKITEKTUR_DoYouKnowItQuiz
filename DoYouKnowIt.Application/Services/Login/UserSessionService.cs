using Domain.Entities.Models;
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
        public UserSessionService()
        {
            
        }

        public UserSession GetSession()
        {
            throw new NotImplementedException();
        }

        public void SetSessionActive(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void SetSessionInactive()
        {
            throw new NotImplementedException();
        }
    }
}
