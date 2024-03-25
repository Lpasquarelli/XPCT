using FluentValidation;
using XPCT.WebAPI.Models.Request.Product;

namespace XPCT.WebAPI.Validators.Product
{
    /// <summary>
    /// Classe validadora de <see cref="EnableProductRequest"/>
    /// </summary>
    public class EnableProductRequestValidator : AbstractValidator<EnableProductRequest>
    {
        /// <summary>
        /// Regras de validação
        /// </summary>
        public EnableProductRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("O código do produto é obrigatório");
        }
    }
}
