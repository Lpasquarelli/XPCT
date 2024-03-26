namespace XPCT.Application.Results.User
{
    /// <summary>
    /// Status de resultado de token do usuário
    /// </summary>
    public enum UserTokenStatus
    {
        Success,
        UserNotFound,
        InternalError,
        ErrorGeneratingUserToken
    }

    /// <summary>
    /// Resultado de token do usuário
    /// </summary>
    public class UserTokenResult
    {
        /// <summary>
        /// <see cref="UserTokenStatus"/>
        /// </summary>
        public UserTokenStatus Status { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Token do Usuario
        /// </summary>
        public string? Token { get; private set; }

        /// <summary>
        /// Data de vencimento do token
        /// </summary>
        public DateTime? DueDate { get; private set; }

        /// <summary>
        /// Instancia um <see cref="UserTokenResult"/>
        /// </summary>
        /// <param name="status"><see cref="UserTokenStatus"/></param>
        /// <param name="message">mensagem de retorno</param>
        /// <param name="token">topken do usuario</param>
        /// <param name="dueDate">data de vencimento do token</param>
        public UserTokenResult(UserTokenStatus status, string message, string? token, DateTime? dueDate)
        {
            Status = status;
            Message = message;
            Token = token;
            DueDate = dueDate;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="token">token do usuario</param>
        /// <param name="dueDate">data de vencimento</param>
        /// <returns><see cref="UserTokenResult"/></returns>
        public static UserTokenResult Success(string token, DateTime dueDate) =>
            new(UserTokenStatus.Success, "Token generated successfully", token, dueDate);

        /// <summary>
        /// Reusltado de usuario nao encontrado
        /// </summary>
        /// <returns><see cref="UserTokenResult"/></returns>
        public static UserTokenResult UserNotFound() =>
            new(UserTokenStatus.UserNotFound, "the user was not found", null, null);

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="UserTokenResult"/></returns>
        public static UserTokenResult InternalError(string message) =>
            new(UserTokenStatus.InternalError, message, null, null);

        /// <summary>
        /// Resultado de Erro gerando token do usuário
        /// </summary>
        /// <returns><see cref="UserTokenResult"/></returns>
        public static UserTokenResult ErrorGeneratingUserToken() =>
            new(UserTokenStatus.ErrorGeneratingUserToken, "an error occoured at generating the user token", null, null);
    }
}
