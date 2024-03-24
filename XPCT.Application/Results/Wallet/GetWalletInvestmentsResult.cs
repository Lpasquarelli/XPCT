using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Wallet
{
    public enum GetWalletInvestmentsStatus
    {
        Success,
        WalletNotFound,
        UserNotFound,
        ErrorSearchingWalletInvestments,
        InternalError
    }
    public class GetWalletInvestmentsResult
    {
        public GetWalletInvestmentsStatus Status { get; private set; }
        public string Message { get; private set; }
        public InvestmentsResponse? Investment {  get; private set; }

        public GetWalletInvestmentsResult(GetWalletInvestmentsStatus status, string message, InvestmentsResponse? investment)
        {
            Status = status;
            Message = message;
            Investment = investment;
        }

        public static GetWalletInvestmentsResult Success(List<Investment> investments) =>
            new(GetWalletInvestmentsStatus.Success, "the investments was searched successfully", new InvestmentsResponse(investments));
        public static GetWalletInvestmentsResult WalletNotFound() =>
            new(GetWalletInvestmentsStatus.WalletNotFound, "the wallet was not found", null);
        public static GetWalletInvestmentsResult UserNotFound() =>
            new(GetWalletInvestmentsStatus.UserNotFound, "the user was not found", null);
        public static GetWalletInvestmentsResult ErrorSearchingWalletExtract() =>
            new(GetWalletInvestmentsStatus.ErrorSearchingWalletInvestments, "an error when searching wallet investments has occoured", null);
        public static GetWalletInvestmentsResult InternalError(string message) =>
            new(GetWalletInvestmentsStatus.WalletNotFound, message, null);
    }
}
