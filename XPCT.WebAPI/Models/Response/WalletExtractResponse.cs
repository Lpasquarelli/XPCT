using XPCT.Application.DTO.Response;

namespace XPCT.WebAPI.Models.Response
{
    public class WalletExtractResponse
    {
        public string Message { get; private set; }
        public ExtractResponse Extract { get; private set; }

        public WalletExtractResponse(string message, ExtractResponse extract)
        {
            Message = message;
            Extract = extract;
        }
    }
}
