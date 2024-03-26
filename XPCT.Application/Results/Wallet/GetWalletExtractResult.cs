using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Wallet
{
    /// <summary>
    /// Status de Resultado da consulta de extrato da carteira 
    /// </summary>
    public enum GetWalletExtractStatus
    {
        Success,
        WalletNotFound,
        UserNotFound,
        ErrorSearchingWalletExtract,
        InternalError
    }

    /// <summary>
    /// Resultado da consulta de extrato da carteira 
    /// </summary>
    public class GetWalletExtractResult
    {
        /// <summary>
        /// <see cref="GetWalletExtractStatus"/>
        /// </summary>
        public GetWalletExtractStatus Status { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="ExtractResponse"/>
        /// </summary>
        public ExtractResponse? Extract {  get; private set; }

        /// <summary>
        /// Instancia um <see cref="GetWalletExtractResult"/>
        /// </summary>
        /// <param name="status"><see cref="GetWalletExtractStatus"/></param>
        /// <param name="message">Mensagem de retorno</param>
        /// <param name="extract"><see cref="ExtractResponse"/></param>
        public GetWalletExtractResult(GetWalletExtractStatus status, string message, ExtractResponse? extract)
        {
            Status = status;
            Message = message;
            Extract = extract;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="transactions"><see cref="IEnumerable{T}"/> de <see cref="Transaction"/></param>
        /// <returns><see cref="GetWalletExtractResult"/></returns>
        public static GetWalletExtractResult Success(IEnumerable<Transaction> transactions) =>
            new(GetWalletExtractStatus.Success, "the extract was searched successfully", new ExtractResponse(transactions));

        /// <summary>
        /// Resultado de Carteira nao encontrada
        /// </summary>
        /// <returns><see cref="GetWalletExtractResult"/></returns>
        public static GetWalletExtractResult WalletNotFound() =>
            new(GetWalletExtractStatus.WalletNotFound, "the wallet was not found", null);

        /// <summary>
        /// Resultado de Usuário não encontrado
        /// </summary>
        /// <returns><see cref="GetWalletExtractResult"/></returns>
        public static GetWalletExtractResult UserNotFound() =>
            new(GetWalletExtractStatus.UserNotFound, "the user was not found", null);

        /// <summary>
        /// Resultado de erro procurando os extratos da carteira
        /// </summary>
        /// <returns><see cref="GetWalletExtractResult"/></returns>
        public static GetWalletExtractResult ErrorSearchingWalletExtract() =>
            new(GetWalletExtractStatus.ErrorSearchingWalletExtract, "an error when searching wallet extract has occoured", null);

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="GetWalletExtractResult"/></returns>
        public static GetWalletExtractResult InternalError(string message) =>
            new(GetWalletExtractStatus.WalletNotFound, message, null);
    }
}
