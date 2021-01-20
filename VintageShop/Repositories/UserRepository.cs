using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VintageShop.IRepositories;
using VintageShop.Models;
using VintageShop.Data;

namespace VintageShop.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(StoreDbContext context) : base(context)
        {
        }

        public User GetByUserAndPassword(string username, string password)
        {
            return DbSet.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
        }
    }
}
