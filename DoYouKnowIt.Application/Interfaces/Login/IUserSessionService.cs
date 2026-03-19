using Domain.Entities.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces.NewFolder
{
    public interface IUserSessionService
    {

        public UserSession GetSession();
        public void SetSessionActive(string username, string password);

        public void SetSessionInactive();
    }
}
