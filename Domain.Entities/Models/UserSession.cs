using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class UserSession
    {
        private static readonly UserSession _currentSession = new UserSession();

        private UserSession()
        {
            
        }

        public static UserSession GetUserSession()
        {
            return _currentSession;
        }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsLoggedIn { get; set; } = false;
    }
}
