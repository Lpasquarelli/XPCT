using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    /// <summary>
    /// Resposta de Indentificação de produto
    /// </summary>
    public class ProductIdentifyerResponse
    {
        /// <summary>
        /// Código do produto
        /// </summary>
        [SwaggerSchema(Description = "Código do Produto")]
        public Guid Id { get; set; }

        /// <summary>
        /// Mensagem
        /// </summary>
        [SwaggerSchema(Description = "Mensagem de retorno")]
        public string Message { get; set; }

        /// <summary>
        /// Instancia um <see cref="ProductIdentifyerResponse"/>
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <param name="message">mensagem</param>
        public ProductIdentifyerResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }
    }
}
