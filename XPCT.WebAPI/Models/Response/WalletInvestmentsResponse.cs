using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.DTO.Response;

namespace XPCT.WebAPI.Models.Response
{
    public class WalletInvestmentsResponse
    {
        [SwaggerSchema(Description = "Mensagem de resposta")]
        public string Message { get; private set; }
        [SwaggerSchema(Description = "Respostas de Investimentos")]
        public InvestmentsResponse Investments { get; private set; }

        public WalletInvestmentsResponse(string message, InvestmentsResponse investments)
        {
            Message = message;
            Investments = investments;
        }
    }
}
