using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class UserSession
    {

        private static readonly UserSession _thisInstance = new UserSession();
        //Singelton - The user only needs to login one time when using the application

        public static UserSession GetSession() 
        { 
            return _thisInstance;
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

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsLoggedIn { get; set; } = false;
    }
}
