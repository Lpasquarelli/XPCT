using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    public class UserIdentifyerResponse
    {
        [SwaggerSchema(Description = "Código do Usuário")]
        public Guid Id { get; set; }
        [SwaggerSchema(Description = "Mensagem de retorno")]
        public string Message { get; set; }

        public UserIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
