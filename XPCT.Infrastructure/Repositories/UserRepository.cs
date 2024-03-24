using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> Users = new();

        public User GetUserByEmail(string email) => Users.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
        public User GetUserById(Guid id) => Users.FirstOrDefault(x => x.Id == id);
        public User CreateUser(User user)
        {
            Users.Add(user);
            return user;
        }

        public bool CreateUserWallet(Guid id, Wallet wallet)
        {
            try
            {
                var user = Users.FirstOrDefault(x => x.Id == id);
                user!.LoadWallet(wallet);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
