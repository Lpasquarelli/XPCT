using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.Wallet
{
    /// <summary>
    /// Status de resultado de compra de investimentos
    /// </summary>
    public enum BuyInvestmentStatus
    {
        InternalError,
        ErrorSearchingProduct,
        ErrorBuyingTheProduct,
        WalletNotFound,
        UserNotFound,
        Success
    }

    /// <summary>
    /// Resultado de compra de investimento
    /// </summary>
    public class BuyInvestmentResult
    {
        /// <summary>
        /// <see cref="BuyInvestmentStatus"/>
        /// </summary>
        public BuyInvestmentStatus Status { get;private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="IdentifyerResponse"/>
        /// </summary>
        public IdentifyerResponse? Wallet { get; set; }

        /// <summary>
        /// Instancia um <see cref="BuyInvestmentResult"/>
        /// </summary>
        /// <param name="status"><see cref="BuyInvestmentStatus"/></param>
        /// <param name="message">Mensagem de retorno</param>
        /// <param name="wallet"><see cref="IdentifyerResponse"/></param>
        public BuyInvestmentResult(BuyInvestmentStatus status, string message, IdentifyerResponse? wallet)
        {
            Status = status;
            Message = message;
            Wallet = wallet;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="id">código da carteira</param>
        /// <returns><see cref="BuyInvestmentResult"/></returns>
        public static BuyInvestmentResult Success(Guid id) =>
            new BuyInvestmentResult(BuyInvestmentStatus.Success, "The Investment was purchased successfully", new IdentifyerResponse(id));

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">Mensagem de Retorno</param>
        /// <returns><see cref="BuyInvestmentResult"/></returns>
        public static BuyInvestmentResult InternalError(string message) =>
            new BuyInvestmentResult(BuyInvestmentStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de Erro procurando o produto
        /// </summary>
        /// <param name="message">Mensagem de Retorno</param>
        /// <returns><see cref="BuyInvestmentResult"/></returns>
        public static BuyInvestmentResult ErrorSearchingProduct(string message) =>
            new BuyInvestmentResult(BuyInvestmentStatus.ErrorSearchingProduct, message, null);

        /// <summary>
        /// Resultado de carteira nao econtrada
        /// </summary>
        /// <returns><see cref="BuyInvestmentResult"/></returns>
        public static BuyInvestmentResult WalletNotFound() =>
            new BuyInvestmentResult(BuyInvestmentStatus.WalletNotFound, "The user's wallet was not found", null);

        /// <summary>
        /// Resultado de Erro tentando comprar o produto
        /// </summary>
        /// <returns><see cref="BuyInvestmentResult"/></returns>
        public static BuyInvestmentResult ErrorBuyingTheProduct() =>
            new BuyInvestmentResult(BuyInvestmentStatus.ErrorBuyingTheProduct, "Error trying to buy the product", null);

        /// <summary>
        /// Resultado de Usuario nao encontrado
        /// </summary>
        /// <returns><see cref="BuyInvestmentResult"/></returns>
        public static BuyInvestmentResult UserNotFound() =>
            new BuyInvestmentResult(BuyInvestmentStatus.UserNotFound, "The user was not found", null);
    }
}
