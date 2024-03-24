using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.Wallet
{
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
    public class SellInvestmentResult
    {
        public SellInvestmentStatus Status { get;private set; }
        public string Message { get; private set; }
        public IdentifyerResponse? Wallet { get; set; }

        public SellInvestmentResult(SellInvestmentStatus status, string message, IdentifyerResponse? wallet)
        {
            Status = status;
            Message = message;
            Wallet = wallet;
        }

        public static SellInvestmentResult Success(Guid id) =>
            new(SellInvestmentStatus.Success, "The Investment was sold successfully", new IdentifyerResponse(id));

        public static SellInvestmentResult InternalError(string message) =>
            new(SellInvestmentStatus.InternalError, message, null);

        public static SellInvestmentResult ErrorSearchingProduct(string message) =>
            new(SellInvestmentStatus.ErrorSearchingProduct, message, null);

        public static SellInvestmentResult WalletNotFound() =>
            new(SellInvestmentStatus.WalletNotFound, "The user's wallet was not found", null);
        public static SellInvestmentResult UserNotFound() =>
            new(SellInvestmentStatus.UserNotFound, "The user was not found", null);

        public static SellInvestmentResult ErrorSellingTheProduct() =>
            new(SellInvestmentStatus.ErrorSellingTheProduct, "Error trying to sell the product", null);
        public static SellInvestmentResult InvestmentNotFoundOnWallet() =>
            new(SellInvestmentStatus.InvestmentNotFoundOnWallet, "The Investment was not found on this client's wallet", null);
        public static SellInvestmentResult NotEnoughQuantityOnWallet() =>
            new(SellInvestmentStatus.NotEnoughQuantityOnWallet, "The Investment's quantity was inferior to the informed value", null);


    }
}
