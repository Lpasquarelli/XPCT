using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.Wallet
{
    /// <summary>
    /// Status de resultado de venda de investimentos 
    /// </summary>
    public enum SellInvestmentStatus
    {
        InternalError,
        ErrorSearchingProduct,
        ErrorSellingTheProduct,
        WalletNotFound,
        UserNotFound,
        Success,
        InvestmentNotFoundOnWallet,
        NotEnoughQuantityOnWallet
    }

    /// <summary>
    /// Resultado de Venda de inestimento
    /// </summary>
    public class SellInvestmentResult
    {
        /// <summary>
        /// <see cref="SellInvestmentStatus"/>
        /// </summary>
        public SellInvestmentStatus Status { get;private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="IdentifyerResponse"/>
        /// </summary>
        public IdentifyerResponse? Wallet { get; set; }

        /// <summary>
        /// Instancia um <see cref="SellInvestmentResult"/>
        /// </summary>
        /// <param name="status"><see cref="SellInvestmentStatus"/></param>
        /// <param name="message">mensagemn de retorno</param>
        /// <param name="wallet"><see cref="IdentifyerResponse"/></param>
        public SellInvestmentResult(SellInvestmentStatus status, string message, IdentifyerResponse? wallet)
        {
            Status = status;
            Message = message;
            Wallet = wallet;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="id">Id da carteira</param>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        public static SellInvestmentResult Success(Guid id) =>
            new(SellInvestmentStatus.Success, "The Investment was sold successfully", new IdentifyerResponse(id));

        /// <summary>
        /// Resultado de Erro interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        public static SellInvestmentResult InternalError(string message) =>
            new(SellInvestmentStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de Erro procurando produtos
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        public static SellInvestmentResult ErrorSearchingProduct(string message) =>
            new(SellInvestmentStatus.ErrorSearchingProduct, message, null);


        /// <summary>
        /// Resultado de carteira nao encontrada
        /// </summary>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        public static SellInvestmentResult WalletNotFound() =>
            new(SellInvestmentStatus.WalletNotFound, "The user's wallet was not found", null);

        /// <summary>
        /// Resultado de usuario nao encontrado
        /// </summary>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        public static SellInvestmentResult UserNotFound() =>
            new(SellInvestmentStatus.UserNotFound, "The user was not found", null);

        /// <summary>
        /// Resultado de erro vendendo o produto
        /// </summary>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        public static SellInvestmentResult ErrorSellingTheProduct() =>
            new(SellInvestmentStatus.ErrorSellingTheProduct, "Error trying to sell the product", null);

        /// <summary>
        /// Resultado de investimento nao encontrado na carteira
        /// </summary>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        public static SellInvestmentResult InvestmentNotFoundOnWallet() =>
            new(SellInvestmentStatus.InvestmentNotFoundOnWallet, "The Investment was not found on this client's wallet", null);

        /// <summary>
        /// Resultado de quantidade insufissiente de investimentos para venda
        /// </summary>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        public static SellInvestmentResult NotEnoughQuantityOnWallet() =>
            new(SellInvestmentStatus.NotEnoughQuantityOnWallet, "The Investment's quantity was inferior to the informed value", null);


    }
}
