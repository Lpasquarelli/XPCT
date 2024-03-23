using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.Product
{
    public class UpdateProductRequest
    {

        [SwaggerSchema(Description = "Código de identificação do produto")]
        public Guid Id { get; set; }

        [SwaggerSchema(Description = "Nome do produto")]
        public string Name { get; set; } = string.Empty;

        [SwaggerSchema(Description = "Preço do produto")]
        public double Price { get; set; } = 0;

        [SwaggerSchema(Description = "Dias para o vencimento do produto")]
        public int DaysToDue { get; set; } = 0;
    }
}
