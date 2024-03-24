using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Infrastructure.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        public List<Transaction> _Transactions = new();
        public List<Wallet> _Wallets = new();

        public Wallet GetWalletById(Guid id)
        {
            return _Wallets.FirstOrDefault(x => x.Id == id);
        }
        public Wallet CreateWallet(Wallet wallet)
        {
            _Wallets.Add(wallet);
            return wallet;
        }

        public Wallet AddInvestmentToWallet(Guid WalletId, Investment investment)
        {
            var wallet = GetWalletById(WalletId);

            if(!wallet.Investments.Any(x => x.Product.Id == investment.Product.Id))
                wallet.Investments.Add(investment);
            else
            {
                var getInvestment = wallet.Investments.First(x => x.Product.Id == investment.Product.Id);
                getInvestment.SumQuantity(investment.Quantity);
            }

            return wallet;
        }

        public Wallet SellInvestment(Guid walletId, Guid productId, double quantity)
        {
            var wallet = GetWalletById(walletId);

            var getInvestment = wallet.Investments.First(x => x.Product.Id == productId);
            if (getInvestment.Quantity > quantity)
                getInvestment.SubtractQuantity(quantity);
            else if (getInvestment.Quantity == quantity)
                wallet.Investments.Remove(getInvestment);
            
            return wallet;
        }

        public void CreateTransaction(Transaction transaction)
        {
            _Transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetExtract(Guid walletId, Guid? productId)
        {
            var completeWallet = _Transactions.Where(x => x.WalletId == walletId);

            if(productId == null || productId == Guid.Empty)
                return completeWallet;

            return completeWallet.Where(x => x.Product.Id == productId);
        }
    }
}
