using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Facades
{
    public interface ILoginFacade
    {
        Task<bool> UserIsAdminAsync(string username, string password);
        public Task<bool> UserLogin(string username, string password);
        public void UserLogout();
    }
}
