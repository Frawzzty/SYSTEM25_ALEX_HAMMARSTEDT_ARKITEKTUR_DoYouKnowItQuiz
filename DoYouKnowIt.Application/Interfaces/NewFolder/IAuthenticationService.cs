using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces.NewFolder
{
    public interface IAuthenticationService
    {
        public bool IsAuthenticated(string username, string password);

    }
}
