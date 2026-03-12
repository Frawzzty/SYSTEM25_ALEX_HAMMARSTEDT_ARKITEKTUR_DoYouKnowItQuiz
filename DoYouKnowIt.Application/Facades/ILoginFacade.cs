using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Facades
{
    public interface ILoginFacade
    {
        bool UserIsAdmin(string username, string password);
    }
}
