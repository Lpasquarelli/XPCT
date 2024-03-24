using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.User
{
    public class AddUserRequest
    {
        [SwaggerSchema(Description = "Nome do Usuário")]
        public string Nome { get; set; }

        [SwaggerSchema(Description = "Email do Usuario")]
        public string Email { get; set; }

        [SwaggerSchema(Description = "Flag para criação de usuário Operador em vez de cliente")]
        public bool Operador { get; set; }

    }
}
