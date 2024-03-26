using FluentValidation;
using XPCT.WebAPI.Models.Request.User;

namespace XPCT.WebAPI.Validators.User
{
    /// <summary>
    /// Classe validadora de <see cref="GenerateUserTokenRequest"/>
    /// </summary>
    public class GenerateUserTokenRequestValidator : AbstractValidator<GenerateUserTokenRequest>
    {
        /// <summary>
        /// Regras de validação
        /// </summary>
        public GenerateUserTokenRequestValidator()
        {
            RuleFor(p => p.userId).NotEmpty().WithMessage("O código do usuário é obrigatório");
        }
    }
}
