using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    /// <summary>
    /// Resposta de token do usuario
    /// </summary>
    public class UserTokenResponse
    {
        /// <summary>
        /// Token
        /// </summary>
        [SwaggerSchema(Description = "Token JWT")]
        public string Token { get; private set; }

        /// <summary>
        /// Data de vencimento do token
        /// </summary>
        [SwaggerSchema(Description = "Data de vencimento do token")]
        public DateTime DueDate { get; private set; }

        /// <summary>
        /// Instancia um <see cref="UserTokenResponse"/>
        /// </summary>
        /// <param name="token">token</param>
        /// <param name="dueDate">data de vencimento</param>
        public UserTokenResponse(string token, DateTime dueDate)
        {
            Token = token;
            DueDate = dueDate;
        }
    }
}
