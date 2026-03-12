using Domain.Entities.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouKnowIt.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByLoginAsync(string username, string password);
    }
}
