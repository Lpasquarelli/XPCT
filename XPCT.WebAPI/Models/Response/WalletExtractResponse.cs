using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.DTO.Response;

namespace XPCT.WebAPI.Models.Response
{
    public class WalletExtractResponse
    {
        [SwaggerSchema(Description = "mensagem de resposta")]
        public string Message { get; private set; }
        [SwaggerSchema(Description = "Resposta de extrato da carteira")]
        public ExtractResponse Extract { get; private set; }

        public WalletExtractResponse(string message, ExtractResponse extract)
        {
            Message = message;
            Extract = extract;
        }
    }
}
