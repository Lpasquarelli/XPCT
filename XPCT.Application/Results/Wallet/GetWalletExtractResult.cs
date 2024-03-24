using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Wallet
{
    public enum GetWalletExtractStatus
    {
        Success,
        WalletNotFound,
        UserNotFound,
        ErrorSearchingWalletExtract,
        InternalError
    }
    public class GetWalletExtractResult
    {
        public GetWalletExtractStatus Status { get; private set; }
        public string Message { get; private set; }
        public ExtractResponse? Extract {  get; private set; }

        public GetWalletExtractResult(GetWalletExtractStatus status, string message, ExtractResponse? extract)
        {
            Status = status;
            Message = message;
            Extract = extract;
        }

        public static GetWalletExtractResult Success(List<Investment> investments) =>
            new(GetWalletExtractStatus.Success, "the extract was searched successfully", new ExtractResponse(investments));
        public static GetWalletExtractResult WalletNotFound() =>
            new(GetWalletExtractStatus.WalletNotFound, "the wallet was not found", null);
        public static GetWalletExtractResult UserNotFound() =>
            new(GetWalletExtractStatus.ErrorSearchingWalletExtract, "the user was not found", null);
        public static GetWalletExtractResult ErrorSearchingWalletExtract() =>
            new(GetWalletExtractStatus.ErrorSearchingWalletExtract, "an error when searching wallet extract has occoured", null);
        public static GetWalletExtractResult InternalError(string message) =>
            new(GetWalletExtractStatus.WalletNotFound, message, null);
    }
}
