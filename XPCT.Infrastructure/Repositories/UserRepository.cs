using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de Usuario
    /// </summary>
    public class UserRepository : IUserRepository
    {
        public List<User> Users = new();

        /// <inheritdoc/>
        public User GetUserByEmail(string email) => Users.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
        /// <inheritdoc/>
        public User GetUserById(Guid id) => Users.FirstOrDefault(x => x.Id == id);
        /// <inheritdoc/>
        public User CreateUser(User user)
        {
            Users.Add(user);
            return user;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public IEnumerable<User> GetUpCommingDueDatenvestmentsByUser()
        {
            var investmentsToExpire = 
                Users.Where(x => !x.Operator).SelectMany(u => u.Wallet!.Investments.Where(i => SubtractDaysToExpire(i.DueDate) <= 10)).ToList();

            var result = new List<User>();

            foreach (var user in Users.Where(x => !x.Operator))
            {

                var userAux = new User(user.Id, user.Name, user.Email, user.Operator);

                var investmentsAux = new List<Investment>();

                foreach (var investment in user.Wallet!.Investments.Where(i => investmentsToExpire.Contains(i)))
                {
                    investmentsAux.Add(investment);
                }
                var walletAux = new Wallet(user.Wallet.Id, investmentsAux);

                userAux.LoadWallet(walletAux);

                if (!userAux.Wallet.Investments.Any())
                    continue;

                result.Add(userAux);
            }

            return result;
        }

        /// <summary>
        /// Subtrai dias da data de vencimento
        /// </summary>
        /// <param name="dueDate">data de vencimento</param>
        /// <returns><see cref="int"/></returns>
        private int SubtractDaysToExpire(DateTime dueDate)
        {
            DateTime currentDate = DateTime.Now.Date;

            TimeSpan difference = dueDate.Date - currentDate;

            return (int)difference.TotalDays;
        }
    }
}
