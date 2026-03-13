using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class UserSession
    {

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsLoggedIn { get; set; } = false;
    }
}
