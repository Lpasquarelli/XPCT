using Swashbuckle.AspNetCore.Annotations;
using XPCT.WebAPI.Validators;

namespace XPCT.WebAPI.Models.Response
{
    /// <summary>
    /// Response para erro na validação
    /// </summary>
    public class BadValidationResponse
    {
        /// <summary>
        /// <see cref="List{T}"/> de <see cref="CustomValidationFailure"/>
        /// </summary>
        [SwaggerSchema(Description = "Lista de falhas de validação")]
        public IList<CustomValidationFailure> Failures { get; private set; } = new List<CustomValidationFailure>();

        /// <summary>
        /// Prefixo de identificação para rastreabilidade do erro
        /// </summary>
        [SwaggerSchema(Description = "Prefixo de identificação para rastreabilidade do erro")]
        public string Prefix { get; private set; }

        /// <summary>
        /// Instancia um <see cref="BadValidationResponse"/>
        /// </summary>
        /// <param name="failures"><see cref="List{T}"/> de <see cref="CustomValidationFailure"/></param>
        /// <param name="prefix">Prefixo de identificação para rastreabilidade do erro</param>
        public BadValidationResponse(IList<CustomValidationFailure> failures, string prefix)
        {
            this.Failures = failures;
            this.Prefix = prefix;
        }

        /// <summary>
        /// Instancia um <see cref="BadValidationResponse"/>
        /// </summary>
        /// <param name="customValidation"><see cref="CustomValidationFailure"/></param>
        /// <param name="prefix">Prefixo de identificação para rastreabilidade do erro</param>
        public BadValidationResponse(CustomValidationFailure customValidation, string prefix)
        {
            this.Failures.Add(customValidation);
            this.Prefix = prefix;
        }
    }
}
