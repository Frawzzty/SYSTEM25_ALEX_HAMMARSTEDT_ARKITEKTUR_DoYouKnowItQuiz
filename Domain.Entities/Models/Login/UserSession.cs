using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models.Login
{
    public class UserSession
    {
        private static readonly UserSession _currentSession = new UserSession();

        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public bool IsLoggedIn { get; private set; } = false;

        private UserSession() { }

        public static UserSession GetUserSession()
        {
            return _currentSession;
        }

        public void SetSessionActive(string username, string password)
        {
            Username = username;
            Password = password;

            IsLoggedIn = true;
        }

        public void SetSessionInactive()
        {
            Username = "";
            Password = "";

            IsLoggedIn = false;
        }


    }
}
