using Swashbuckle.AspNetCore.Annotations;
using XPCT.WebAPI.Validators;

namespace XPCT.WebAPI.Models.Response
{
    public class BadValidationResponse
    {
        [SwaggerSchema(Description = "Lista de falhas de validação")]
        public IList<CustomValidationFailure> Failures { get; private set; } = new List<CustomValidationFailure>();

        [SwaggerSchema(Description = "Prefixo de identificação para rastreabilidade do erro")]
        public string Prefix { get; private set; }

        public BadValidationResponse(IList<CustomValidationFailure> failures, string prefix)
        {
            this.Failures = failures;
            this.Prefix = prefix;
        }

        public BadValidationResponse(CustomValidationFailure customValidation, string prefix)
        {
            this.Failures.Add(customValidation);
            this.Prefix = prefix;
        }
    }
}
