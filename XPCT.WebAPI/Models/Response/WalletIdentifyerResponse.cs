using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    public class WalletIdentifyerResponse
    {
        [SwaggerSchema(Description = "Código da carteira do usuário")]
        public Guid Id { get; set; }
        [SwaggerSchema(Description = "Mensagem de resposta")]
        public string Message { get; set; }

        public WalletIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
