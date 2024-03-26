using XPCT.Application.Results.Wallet;

namespace XPCT.Application.Interfaces
{
    /// <summary>
    /// Interface de Serviço de Carteira
    /// </summary>
    public interface IWalletService
    {
        /// <summary>
        /// Compra de Investimento
        /// </summary>
        /// <param name="userId">código do usuário</param>
        /// <param name="quantity">quantidade de produto</param>
        /// <param name="productId">código do produto</param>
        /// <returns><see cref="BuyInvestmentResult"/></returns>
        BuyInvestmentResult BuyInvestment(Guid userId, double quantity, Guid productId);

        /// <summary>
        /// Venda de Investimento
        /// </summary>
        /// <param name="userId">código do usuário</param>
        /// <param name="quantity">quantidade de produto</param>
        /// <param name="productId">código do produto</param>
        /// <returns><see cref="SellInvestmentResult"/></returns>
        SellInvestmentResult SellInvestment(Guid userId, double quantity, Guid productId);

        /// <summary>
        /// Obter extrato da carteira
        /// </summary>
        /// <param name="userId">código do usuário</param>
        /// <param name="productId">código do produto</param>
        /// <returns><see cref="GetWalletExtractResult"/></returns>
        GetWalletExtractResult GetWalletExtract(Guid userId, Guid? productId);

        /// <summary>
        /// Obter os investimentos da carteira do usuário
        /// </summary>
        /// <param name="userId">código do usuário</param>
        /// <returns><see cref="GetWalletInvestmentsResult"/></returns>
        GetWalletInvestmentsResult GetWalletInvestments(Guid userId);
    }
}
