using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces.LoginInterfaces
{
    public interface IAuthorizationService
    {
        public Task<bool> IsAuthorizedAsync(string role);
    }
}
