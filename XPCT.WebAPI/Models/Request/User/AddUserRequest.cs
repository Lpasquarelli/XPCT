using Swashbuckle.AspNetCore.Annotations;

namespace XPCT.WebAPI.Models.Request.User
{
    /// <summary>
    /// Request de cadastro de usuario
    /// </summary>
    public class AddUserRequest
    {
        /// <summary>
        /// nome do usuario
        /// </summary>
        [SwaggerSchema(Description = "Nome do Usuário")]
        public string Nome { get; set; }

        /// <summary>
        /// email do usuario
        /// </summary>
        [SwaggerSchema(Description = "Email do Usuario")]
        public string Email { get; set; }

        /// <summary>
        /// Flag para criação de usuário Operador em vez de cliente 
        /// </summary>
        [SwaggerSchema(Description = "Flag para criação de usuário Operador em vez de cliente")]
        public bool Operador { get; set; }

    }
}
