using XPCT.Domain.Entities;

namespace XPCT.Domain.Repositories
{
    /// <summary>
    /// Interface de Repositorio de Carteira
    /// </summary>
    public interface IWalletRepository
    {
        /// <summary>
        /// Consulta carteira por id
        /// </summary>
        /// <param name="id">código da carteira</param>
        /// <returns><see cref="Wallet"/></returns>
        Wallet GetWalletById(Guid id);

        /// <summary>
        /// Cria Carteira
        /// </summary>
        /// <param name="wallet"><see cref="Wallet"/></param>
        /// <returns><see cref="Wallet"/></returns>
        Wallet CreateWallet(Wallet wallet);

        /// <summary>
        /// Adiciona Investimento a carteira
        /// </summary>
        /// <param name="walletId">código da carteira</param>
        /// <param name="investment"><see cref="Investment"/></param>
        /// <returns><see cref="Wallet"/></returns>
        Wallet AddInvestmentToWallet(Guid walletId, Investment investment);

        /// <summary>
        /// Vende Investimento
        /// </summary>
        /// <param name="walletId">código da carteira</param>
        /// <param name="productId">código do produto</param>
        /// <param name="quantity">quantidade</param>
        /// <returns><see cref="Wallet"/></returns>
        Wallet SellInvestment(Guid walletId, Guid productId, double quantity);

        /// <summary>
        /// Cria uma transação de operação
        /// </summary>
        /// <param name="transaction"><see cref="Transaction"/></param>
        void CreateTransaction(Transaction transaction);

        /// <summary>
        /// Obtem extrato
        /// </summary>
        /// <param name="walletId">código da carteira</param>
        /// <param name="productId">código do produto</param>
        /// <returns><see cref="IEnumerable{T}"/> de <see cref="Transaction"/></returns>
        IEnumerable<Transaction> GetExtract(Guid walletId, Guid? productId);
    }
}
