using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.Product
{
    public class EnableProductRequest
    {
        [SwaggerSchema(Description = "Código do Produto")]
        public Guid Id { get; set; }
    }
}
