using XPCT.Domain.Entities;

namespace XPCT.Domain.Repositories
{
    /// <summary>
    /// Interface de Repositorio de Usuário
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// obter usuario por email
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <returns><see cref="User"/></returns>
        User GetUserByEmail(string email);

        /// <summary>
        /// Obter usuario por id
        /// </summary>
        /// <param name="id">código do usuário</param>
        /// <returns><see cref="User"/></returns>
        User GetUserById(Guid id);

        /// <summary>
        /// Cria usuário
        /// </summary>
        /// <param name="user"><see cref="User"/></param>
        /// <returns><see cref="User"/></returns>
        User CreateUser(User user);

        /// <summary>
        /// Obter investmentos proximos do vencimento
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> de <see cref="User"/></returns>
        IEnumerable<User> GetUpCommingDueDatenvestmentsByUser();

        /// <summary>
        /// Cria uma carteira de usuario
        /// </summary>
        /// <param name="id">código do usuario</param>
        /// <param name="wallet"><see cref="Wallet"/></param>
        /// <returns></returns>
        bool CreateUserWallet(Guid id, Wallet wallet);
    }
}
