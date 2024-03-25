using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    /// <summary>
    /// Resposta de Identificador de Carteira
    /// </summary>
    public class WalletIdentifyerResponse
    {
        /// <summary>
        /// código da carteira
        /// </summary>
        [SwaggerSchema(Description = "Código da carteira do usuário")]
        public Guid Id { get; set; }

        /// <summary>
        /// mensagem
        /// </summary>
        [SwaggerSchema(Description = "Mensagem de resposta")]
        public string Message { get; set; }

        /// <summary>
        /// Instancia um <see cref="WalletIdentifyerResponse"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public WalletIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
