using Domain.Entities.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByLoginAsync(string username, string password);

    }
}
