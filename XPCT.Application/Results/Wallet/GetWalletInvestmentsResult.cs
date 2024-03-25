using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Wallet
{
    /// <summary>
    /// Status de resultado de investimentos da carteira
    /// </summary>
    public enum GetWalletInvestmentsStatus
    {
        Success,
        WalletNotFound,
        UserNotFound,
        ErrorSearchingWalletInvestments,
        InternalError
    }

    /// <summary>
    /// Resultados da consulta de investimentos da carteira
    /// </summary>
    public class GetWalletInvestmentsResult
    {
        /// <summary>
        /// <see cref="GetWalletInvestmentsStatus"/>
        /// </summary>
        public GetWalletInvestmentsStatus Status { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="InvestmentsResponse"/>
        /// </summary>
        public InvestmentsResponse? Investment {  get; private set; }


        /// <summary>
        /// Instancia um <see cref="GetWalletInvestmentsResult"/>
        /// </summary>
        /// <param name="status"><see cref="GetWalletInvestmentsStatus"/></param>
        /// <param name="message">Mensagem de retorno</param>
        /// <param name="investment"><see cref="InvestmentsResponse"/></param>
        public GetWalletInvestmentsResult(GetWalletInvestmentsStatus status, string message, InvestmentsResponse? investment)
        {
            Status = status;
            Message = message;
            Investment = investment;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="investments"><see cref="List{T}"/> de <see cref="Investment"/></param>
        /// <returns><see cref="GetWalletInvestmentsResult"/></returns>
        public static GetWalletInvestmentsResult Success(List<Investment> investments) =>
            new(GetWalletInvestmentsStatus.Success, "the investments was searched successfully", new InvestmentsResponse(investments));

        /// <summary>
        /// Resultado de Carteira nao encontrada
        /// </summary>
        /// <returns><see cref="GetWalletInvestmentsResult"/></returns>
        public static GetWalletInvestmentsResult WalletNotFound() =>
            new(GetWalletInvestmentsStatus.WalletNotFound, "the wallet was not found", null);

        /// <summary>
        /// Resultado de Usuário não encontrado
        /// </summary>
        /// <returns><see cref="GetWalletInvestmentsResult"/></returns>
        public static GetWalletInvestmentsResult UserNotFound() =>
            new(GetWalletInvestmentsStatus.UserNotFound, "the user was not found", null);

        /// <summary>
        /// Resultado de Erro consultando extrato da carteira
        /// </summary>
        /// <returns><see cref="GetWalletInvestmentsResult"/></returns>
        public static GetWalletInvestmentsResult ErrorSearchingWalletExtract() =>
            new(GetWalletInvestmentsStatus.ErrorSearchingWalletInvestments, "an error when searching wallet investments has occoured", null);

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">mensagem de erro</param>
        /// <returns><see cref="GetWalletInvestmentsResult"/></returns>
        public static GetWalletInvestmentsResult InternalError(string message) =>
            new(GetWalletInvestmentsStatus.WalletNotFound, message, null);
    }
}
