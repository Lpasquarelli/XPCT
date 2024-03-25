using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    /// <summary>
    /// Resposta de Identificação do usuario
    /// </summary>
    public class UserIdentifyerResponse
    {
        /// <summary>
        /// código do usuário
        /// </summary>
        [SwaggerSchema(Description = "Código do Usuário")]
        public Guid Id { get; set; }

        /// <summary>
        /// mensagem
        /// </summary>
        [SwaggerSchema(Description = "Mensagem de retorno")]
        public string Message { get; set; }

        /// <summary>
        /// Instancia um <see cref="UserIdentifyerResponse"/>
        /// </summary>
        /// <param name="id">código do usuario</param>
        /// <param name="message">mensagem</param>
        public UserIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
