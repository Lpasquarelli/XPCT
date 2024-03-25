using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.Wallet
{
    /// <summary>
    /// Request de venda de investimento
    /// </summary>
    public class SellInvestmentsRequest
    {
        /// <summary>
        /// código do usuario
        /// </summary>
        [SwaggerSchema(Description = "Código do Usuário")]
        public Guid UserId { get; set; }
        
        /// <summary>
        /// quantidade de venda
        /// </summary>
        [SwaggerSchema(Description = "Quantidade de venda")]
        public double Quantity { get; set; }

        /// <summary>
        /// código do produto
        /// </summary>
        [SwaggerSchema(Description = "Código do Produto")]
        public Guid ProductId { get; set; }
    }
}
