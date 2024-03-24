using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    public class ProductIdentifyerResponse
    {
        [SwaggerSchema(Description = "Código do Produto")]
        public Guid Id { get; set; }
        [SwaggerSchema(Description = "Mensagem de retorno")]
        public string Message { get; set; }

        public ProductIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
