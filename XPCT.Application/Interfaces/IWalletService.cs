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
        BuyInvestmentResult BuyInvestment(Guid userId, double quantity, Guid productId);
        SellInvestmentResult SellInvestment(Guid userId, double quantity, Guid productId);
        GetWalletExtractResult GetWalletExtract(Guid userId, Guid? productId);
        GetWalletInvestmentsResult GetWalletInvestments(Guid userId);
    }
}
