using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    public class BadRequestResponse
    {
        [SwaggerSchema(Description = "Mensagem do possível erro")]
        public string Message { get; private set; }

        [SwaggerSchema(Description = "Prefixo de identificação para rastreabilidade do erro")]
        public string Prefix { get; private set; }

        public BadRequestResponse(string message, string prefix)
        {
            this.Message = message;
            this.Prefix = prefix;
        }

        public BadRequestResponse(Exception exception, string prefix) 
        {
            this.Prefix = prefix;
            this.Message = exception.Message;
        }
    }
}
