using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    /// <summary>
    /// Resposta de Bad Request
    /// </summary>
    public class BadRequestResponse
    {
        /// <summary>
        /// Mensagem do erro
        /// </summary>
        [SwaggerSchema(Description = "Mensagem do possível erro")]
        public string Message { get; private set; }

        /// <summary>
        /// Prefixo de identificação para rastreabilidade do erro
        /// </summary>
        [SwaggerSchema(Description = "Prefixo de identificação para rastreabilidade do erro")]
        public string Prefix { get; private set; }

        /// <summary>
        /// Instancia um <see cref="BadRequestResponse"/>
        /// </summary>
        /// <param name="message">Mensagem do erro</param>
        /// <param name="prefix">Prefixo de identificação para rastreabilidade do erro</param>
        public BadRequestResponse(string message, string prefix)
        {
            this.Message = message;
            this.Prefix = prefix;
        }

        /// <summary>
        /// Instancia um <see cref="BadRequestResponse"/>
        /// </summary>
        /// <param name="exception"><see cref="Exception"/></param>
        /// <param name="prefix">Prefixo de identificação para rastreabilidade do erro</param>
        public BadRequestResponse(Exception exception, string prefix) 
        {
            this.Prefix = prefix;
            this.Message = exception.Message;
        }
    }
}
