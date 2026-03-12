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
        public bool IsAuthenticated(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return true;
            }

            return false;
        }
    }
}
