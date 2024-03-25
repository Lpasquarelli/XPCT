using FluentValidation;
using XPCT.WebAPI.Models.Request.User;
using XPCT.WebAPI.Models.Request.Wallet;

namespace XPCT.WebAPI.Validators.User
{
    /// <summary>
    /// Classe validadora de <see cref="AddUserRequest"/>
    /// </summary>
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        /// <summary>
        /// Regras de validação
        /// </summary>
        public AddUserRequestValidator()
        {
            RuleFor(p => p.Nome).NotEmpty().WithMessage("O nome do usuário é obrigatório");
            RuleFor(p => p.Email).EmailAddress().NotEmpty().WithMessage("O e-mail do usuário é obrigatório");
        }

    }
}
