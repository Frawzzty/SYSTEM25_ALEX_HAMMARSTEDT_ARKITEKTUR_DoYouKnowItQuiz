using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Facades
{
    public interface ILoginFacade
    {
        Task<bool> UserIsAdminAsync();
        Task<bool> UserIsLoggedIn();
        public Task<bool> UserLogin(string username, string password);
        public void UserLogout();
    }
}
