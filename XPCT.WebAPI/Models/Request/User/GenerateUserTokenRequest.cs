using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.User
{
    /// <summary>
    /// Reqeust de geração de token
    /// </summary>
    public class GenerateUserTokenRequest
    {
        /// <summary>
        /// código do usuário
        /// </summary>
        [SwaggerSchema(Description = "O código do usuário")]
        public Guid userId { get; set; }
    }
}
