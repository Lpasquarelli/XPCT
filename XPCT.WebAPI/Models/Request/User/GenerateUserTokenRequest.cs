using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.User
{
    public class GenerateUserTokenRequest
    {
        [SwaggerSchema(Description = "O código do usuário")]
        public Guid userId { get; set; }
    }
}
