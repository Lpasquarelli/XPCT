namespace XPCT.Application.Results.User
{
    /// <summary>
    /// Status de Obter investimentos com o vencimento proximo
    /// </summary>
    public enum GetUserWalletsUpcommingDueDateStatus
    {
        Success,
        NoContent,
        InternalError,
        ErrorGettingUserWalletsUpcommingDueDateStatus
    }

    /// <summary>
    /// Resultado de investimentos com o vencimento proximo
    /// </summary>
    public class GetUserWalletsUpcommingDueDateResult
    {
        /// <summary>
        /// <see cref="GetUserWalletsUpcommingDueDateStatus"/>
        /// </summary>
        public GetUserWalletsUpcommingDueDateStatus Status { get; private set; }

        /// <summary>
        /// <see cref="Domain.Entities.User"/>
        /// </summary>
        public IEnumerable<Domain.Entities.User>? Users { get; private set; }

        /// <summary>
        /// Mensagem de Retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Instancia um <see cref="GetUserWalletsUpcommingDueDateResult"/>
        /// </summary>
        /// <param name="status"><see cref="GetUserWalletsUpcommingDueDateStatus"/></param>
        /// <param name="message">mensagem de retorno</param>
        /// <param name="users"><see cref="IEnumerable{T}"/> de <see cref="Domain.Entities.User"/></param>
        public GetUserWalletsUpcommingDueDateResult(GetUserWalletsUpcommingDueDateStatus status, string message, IEnumerable<Domain.Entities.User>? users)
        {
            Status = status;
            Message = message;
            Users = users;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="users"><see cref="IEnumerable{T}"/> de <see cref="Domain.Entities.User"/></param>
        /// <returns><see cref="GetUserWalletsUpcommingDueDateResult"/></returns>
        public static GetUserWalletsUpcommingDueDateResult Success(IEnumerable<Domain.Entities.User>? users) =>
            new(GetUserWalletsUpcommingDueDateStatus.Success, "researching completed successfully",users);

        /// <summary>
        /// Resultado de Nenhum conteúdo
        /// </summary>
        /// <returns><see cref="GetUserWalletsUpcommingDueDateResult"/></returns>
        public static GetUserWalletsUpcommingDueDateResult NoContent() =>
            new(GetUserWalletsUpcommingDueDateStatus.NoContent, "no content was found", null);

        /// <summary>
        /// Resultado de Erro procurando investimentos com vencimento proximo
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="GetUserWalletsUpcommingDueDateResult"/></returns>
        public static GetUserWalletsUpcommingDueDateResult ErrorGettingUserWalletsUpcommingDueDateStatus(string message) =>
            new(GetUserWalletsUpcommingDueDateStatus.ErrorGettingUserWalletsUpcommingDueDateStatus, message, null);

        /// <summary>
        /// Resultado de Erro interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="GetUserWalletsUpcommingDueDateResult"/></returns>
        public static GetUserWalletsUpcommingDueDateResult InternalError(string message) =>
            new(GetUserWalletsUpcommingDueDateStatus.InternalError, message, null);
    }
}
