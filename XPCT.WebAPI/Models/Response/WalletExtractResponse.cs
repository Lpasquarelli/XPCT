using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.DTO.Response;

namespace XPCT.WebAPI.Models.Response
{
    /// <summary>
    /// Resposta de extrato de carteira
    /// </summary>
    public class WalletExtractResponse
    {
        /// <summary>
        /// mensagem
        /// </summary>
        [SwaggerSchema(Description = "mensagem de resposta")]
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="ExtractResponse"/>
        /// </summary>
        [SwaggerSchema(Description = "Resposta de extrato da carteira")]
        public ExtractResponse Extract { get; private set; }

        /// <summary>
        /// instancia um <see cref="WalletExtractResponse"/>
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <param name="extract"><see cref="ExtractResponse"/></param>
        public WalletExtractResponse(string message, ExtractResponse extract)
        {
            Message = message;
            Extract = extract;
        }
    }
}
