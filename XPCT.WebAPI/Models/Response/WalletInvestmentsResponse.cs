using XPCT.Application.DTO.Response;

namespace XPCT.WebAPI.Models.Response
{
    public class WalletInvestmentsResponse
    {
        public string Message { get; private set; }
        public InvestmentsResponse Investments { get; private set; }

        public WalletInvestmentsResponse(string message, InvestmentsResponse investments)
        {
            Message = message;
            Investments = investments;
        }
    }
}
