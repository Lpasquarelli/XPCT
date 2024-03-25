using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.DTO.Response;

namespace XPCT.WebAPI.Models.Response
{
    /// <summary>
    /// Resposta de Investimentos da carteira
    /// </summary>
    public class WalletInvestmentsResponse
    {
        /// <summary>
        /// mensagem
        /// </summary>
        [SwaggerSchema(Description = "Mensagem de resposta")]
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="InvestmentsResponse"/>
        /// </summary>
        [SwaggerSchema(Description = "Respostas de Investimentos")]
        public InvestmentsResponse Investments { get; private set; }

        /// <summary>
        /// Instancia um <see cref="WalletInvestmentsResponse"/>
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <param name="investments"><see cref="InvestmentsResponse"/></param>
        public WalletInvestmentsResponse(string message, InvestmentsResponse investments)
        {
            Message = message;
            Investments = investments;
        }
    }
}
