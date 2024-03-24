using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.Results.User;

namespace XPCT.Application.Interfaces
{
    public interface IUserService
    {
        Task<AddUserResult> AddUser(string nome, string email, bool operador);
        Task<UserTokenResult> GenerateUserTokenAsync(Guid userId);
    }
}
