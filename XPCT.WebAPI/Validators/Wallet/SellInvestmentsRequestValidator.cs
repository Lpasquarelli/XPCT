using FluentValidation;
using XPCT.WebAPI.Models.Request.Wallet;

namespace XPCT.WebAPI.Validators.Wallet
{
    /// <summary>
    /// classe validadora de <see cref="SellInvestmentsRequest"/>
    /// </summary>
    public class SellInvestmentsRequestValidator : AbstractValidator<SellInvestmentsRequest>
    {
        /// <summary>
        /// Regras de validação
        /// </summary>
        public SellInvestmentsRequestValidator()
        {
            RuleFor(p => p.UserId).NotEmpty().WithMessage("O código do usuário é obrigatório");
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("O código do produto é obrigatório");
            RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("O quantidade deverá ser maior que 0");
        }
    
    }
}
