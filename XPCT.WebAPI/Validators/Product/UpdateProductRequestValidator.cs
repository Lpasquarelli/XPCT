using FluentValidation;
using XPCT.WebAPI.Models.Request.Product;

namespace XPCT.WebAPI.Validators.Product
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("O código do produto é obrigatório");
            RuleFor(p => p.Name).NotEmpty().WithMessage("O nome do produto é obrigatório");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("O preço precisa ser maior que 0");
            RuleFor(p => p.DaysToDue).GreaterThan(0).WithMessage("Os dias até o vencimento do produto deve ser maior que 0");
        }
    }
}
