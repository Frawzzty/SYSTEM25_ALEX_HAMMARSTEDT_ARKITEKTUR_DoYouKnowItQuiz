using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces.NewFolder
{
    public interface IAuthorizationService
    {
        public Task<bool> IsAuthorizedAsync(string username, string password, string role);
    }
}
