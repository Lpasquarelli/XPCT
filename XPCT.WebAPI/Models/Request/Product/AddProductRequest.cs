using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.Product
{
    /// <summary>
    /// Classe de Request de Produto
    /// </summary>
    public class AddProductRequest
    {
        /// <summary>
        /// Nome do Produto
        /// </summary>
        [SwaggerSchema(Description = "Nome do produto")]
        public string Name { get; set; } = string.Empty; 

        /// <summary>
        /// Preço do produto
        /// </summary>
        [SwaggerSchema(Description = "Preço do produto")]
        public double Price { get; set; } = 0;

        /// <summary>
        /// Flag de ativação do produto
        /// </summary>
        [SwaggerSchema(Description = "Flag de ativação do produto")]
        public bool Active { get; set; } = true;

        /// <summary>
        /// Dias para o vencimento do produto após a compra
        /// </summary>
        [SwaggerSchema(Description = "Dias para o vencimento do produto")]
        public int DaysToDue { get; set; } = 0;
    }
}
