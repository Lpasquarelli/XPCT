using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.Product
{
    /// <summary>
    /// Classe de Request de Edição do Produto
    /// </summary>
    public class UpdateProductRequest
    {
        /// <summary>
        /// Código do produto
        /// </summary>
        [SwaggerSchema(Description = "Código de identificação do produto")]
        public Guid Id { get; set; }

        /// <summary>
        /// nome do produto
        /// </summary>
        [SwaggerSchema(Description = "Nome do produto")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Preço do produto
        /// </summary>
        [SwaggerSchema(Description = "Preço do produto")]
        public double Price { get; set; } = 0;

        /// <summary>
        /// Dias para o vencimento do produto após a compra
        /// </summary>
        [SwaggerSchema(Description = "Dias para o vencimento do produto")]
        public int DaysToDue { get; set; } = 0;
    }
}
