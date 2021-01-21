using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.Models;

namespace VintageShop.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUserAndPassword(string username, string password);

    }
}

