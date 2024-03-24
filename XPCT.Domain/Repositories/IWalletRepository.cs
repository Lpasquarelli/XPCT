using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;

namespace XPCT.Domain.Repositories
{
    public interface IWalletRepository
    {
        Wallet GetWalletByIdAsync(Guid id);
        Wallet CreateWalletAsync(Wallet wallet);

        Wallet AddInvestmentToWallet(Guid walletId, Investment investment);
        Wallet SellInvestment(Guid walletId, Guid productId, double quantity);

        void CreateTransaction(Transaction transaction);
        IEnumerable<Transaction> GetExtract(Guid walletId, Guid? productId);
    }
}
