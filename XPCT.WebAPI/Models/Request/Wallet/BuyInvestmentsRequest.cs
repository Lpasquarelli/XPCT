using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.Wallet
{
    public class BuyInvestmentsRequest
    {
        [SwaggerSchema(Description = "Código do Usuário")]
        public Guid UserId { get; set; }
        
        [SwaggerSchema(Description = "Quantidade de compra")]
        public double Quantity { get; set; }

        [SwaggerSchema(Description = "Código do Produto")]
        public Guid ProductId { get; set; }
    }
}
