using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces.NewFolder
{
    public interface IValidationService
    {
        public bool IsValidated(string userName, string password);
    }
}
