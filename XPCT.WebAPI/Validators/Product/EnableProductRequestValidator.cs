using FluentValidation;
using XPCT.WebAPI.Models.Request.Product;

namespace XPCT.WebAPI.Validators.Product
{
    public class EnableProductRequestValidator : AbstractValidator<EnableProductRequest>
    {
        public EnableProductRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("O código do produto é obrigatório");
        }
    }
}
