using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.Wallet
{
    public enum BuyInvestmentStatus
    {
        InternalError,
        ErrorSearchingProduct,
        ErrorBuyingTheProduct,
        WalletNotFound,
        UserNotFound,
        Success
    }
    public class BuyInvestmentResult
    {
        public BuyInvestmentStatus Status { get;private set; }
        public string Message { get; private set; }
        public IdentifyerResponse? Wallet { get; set; }

        public BuyInvestmentResult(BuyInvestmentStatus status, string message, IdentifyerResponse? wallet)
        {
            Status = status;
            Message = message;
            Wallet = wallet;
        }

        public static BuyInvestmentResult Success(Guid id) =>
            new BuyInvestmentResult(BuyInvestmentStatus.Success, "The Investment was purchased successfully", new IdentifyerResponse(id));

        public static BuyInvestmentResult InternalError(string message) =>
            new BuyInvestmentResult(BuyInvestmentStatus.InternalError, message, null);

        public static BuyInvestmentResult ErrorSearchingProduct(string message) =>
            new BuyInvestmentResult(BuyInvestmentStatus.ErrorSearchingProduct, message, null);

        public static BuyInvestmentResult WalletNotFound() =>
            new BuyInvestmentResult(BuyInvestmentStatus.WalletNotFound, "The user's wallet was not found", null);

        public static BuyInvestmentResult ErrorBuyingTheProduct() =>
            new BuyInvestmentResult(BuyInvestmentStatus.ErrorBuyingTheProduct, "Error trying to buy the product", null);
        public static BuyInvestmentResult UserNotFound() =>
            new BuyInvestmentResult(BuyInvestmentStatus.UserNotFound, "The user was not found", null);
    }
}
