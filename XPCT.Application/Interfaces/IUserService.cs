using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.Results.User;

namespace XPCT.Application.Interfaces
{
    /// <summary>
    /// Interface de Serviço de Usuário
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Criar Usuário
        /// </summary>
        /// <param name="nome">nome do usuário</param>
        /// <param name="email">email do usuário</param>
        /// <param name="operador">flag de operador/cliente</param>
        /// <returns><see cref="AddUserResult"/></returns>
        AddUserResult AddUser(string nome, string email, bool operador);

        /// <summary>
        /// Gerar token de acesso
        /// </summary>
        /// <param name="userId">código do usuário</param>
        /// <returns></returns>
        UserTokenResult GenerateUserToken(Guid userId);

        /// <summary>
        /// Obter investimentos que estão proximos da data de vencimento da carteira do usuário
        /// </summary>
        /// <returns><see cref="GetUserWalletsUpcommingDueDateResult"/></returns>
        GetUserWalletsUpcommingDueDateResult GetUserWalletsUpcommingDueDate();
    }
}
