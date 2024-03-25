using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.Wallet
{
    /// <summary>
    /// Request para compra de investimentos
    /// </summary>
    public class BuyInvestmentsRequest
    {
        /// <summary>
        /// código do usuário
        /// </summary>
        [SwaggerSchema(Description = "Código do Usuário")]
        public Guid UserId { get; set; }
        
        /// <summary>
        /// quantidade de compra
        /// </summary>
        [SwaggerSchema(Description = "Quantidade de compra")]
        public double Quantity { get; set; }

        /// <summary>
        /// código do produto
        /// </summary>
        [SwaggerSchema(Description = "Código do Produto")]
        public Guid ProductId { get; set; }
    }
}
