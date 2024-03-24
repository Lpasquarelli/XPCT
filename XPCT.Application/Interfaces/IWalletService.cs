using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.Results.Wallet;

namespace XPCT.Application.Interfaces
{
    public interface IWalletService
    {
        Task<BuyInvestmentResult> BuyInvestmentAsync(Guid userId, double quantity, Guid productId);
        Task<SellInvestmentResult> SellInvestmentAsync(Guid userId, double quantity, Guid productId);
    }
}
