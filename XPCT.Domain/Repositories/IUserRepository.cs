using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;

namespace XPCT.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        User GetUserById(Guid id);
        User CreateUser(User user);

        bool CreateUserWallet(Guid id, Wallet wallet);
    }
}
