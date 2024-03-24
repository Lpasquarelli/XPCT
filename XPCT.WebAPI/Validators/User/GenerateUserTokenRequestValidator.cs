using FluentValidation;
using XPCT.WebAPI.Models.Request.User;
using XPCT.WebAPI.Models.Request.Wallet;

namespace XPCT.WebAPI.Validators.User
{
    public class GenerateUserTokenRequestValidator : AbstractValidator<GenerateUserTokenRequest>
    {
        public GenerateUserTokenRequestValidator()
        {
            RuleFor(p => p.userId).NotEmpty().WithMessage("O código do usuário é obrigatório");
        }
    }
}
