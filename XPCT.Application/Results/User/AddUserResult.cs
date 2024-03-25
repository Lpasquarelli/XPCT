using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.User
{
    /// <summary>
    /// Status de Resultado de criação de usuário
    /// </summary>
    public enum AddUserStatus
    {
        Success,
        ErrorCreatingUser,
        InternalError,
        EmailAlreadyUsing
    }

    /// <summary>
    /// Resultado de Criação de usuário
    /// </summary>
    public class AddUserResult
    {
        /// <summary>
        /// <see cref="AddUserStatus"/>
        /// </summary>
        public AddUserStatus Status { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="IdentifyerResponse"/>
        /// </summary>
        public IdentifyerResponse? User { get; private set; }

        /// <summary>
        /// Instancia um <see cref="AddUserResult"/>
        /// </summary>
        /// <param name="status"><see cref="AddUserStatus"/></param>
        /// <param name="message">mensagem de retorno</param>
        /// <param name="user"><see cref="IdentifyerResponse"/></param>
        public AddUserResult(AddUserStatus status, string message, IdentifyerResponse? user)
        {
            Status = status;
            Message = message;
            User = user;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="id">código do usuário</param>
        /// <returns><see cref="AddUserResult"/></returns>
        public static AddUserResult Success(Guid id) =>
            new AddUserResult(AddUserStatus.Success, "User registered successfully", new IdentifyerResponse(id));

        /// <summary>
        /// Resultado de erro criando usuário
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="AddUserResult"/></returns>
        public static AddUserResult ErrorCreatingUser(string message) =>
            new AddUserResult(AddUserStatus.ErrorCreatingUser, message, null);

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="AddUserResult"/></returns>
        public static AddUserResult InternalError(string message) =>
            new AddUserResult(AddUserStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de email já utilizado
        /// </summary>
        /// <returns><see cref="AddUserResult"/></returns>
        public static AddUserResult EmailAlreadyUsing() =>
            new AddUserResult(AddUserStatus.EmailAlreadyUsing, "the email is already in use, please try another", null);

    }
}
