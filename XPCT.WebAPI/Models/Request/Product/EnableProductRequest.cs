using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.Product
{
    /// <summary>
    /// Classe de Request de Ativação de produto
    /// </summary>
    public class EnableProductRequest
    {
        /// <summary>
        /// Código do Produto
        /// </summary>
        [SwaggerSchema(Description = "Código do Produto")]
        public Guid Id { get; set; }
    }
}
