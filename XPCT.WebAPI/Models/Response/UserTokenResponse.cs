using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Response
{
    public class UserTokenResponse
    {
        [SwaggerSchema(Description = "Token JWT")]
        public string Token { get; private set; }
        [SwaggerSchema(Description = "Data de vencimento do token")]
        public DateTime DueDate { get; private set; }

        public UserTokenResponse(string token, DateTime dueDate)
        {
            Token = token;
            DueDate = dueDate;
        }
    }
}
