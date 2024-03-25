using FluentValidation.Results;

namespace XPCT.WebAPI.Validators
{
    /// <summary>
    /// Extenção de falha de validação da classe <see cref="ValidationFailure"/>
    /// </summary>
    public static class ValidationFailureExtesions
    {
        /// <summary>
        /// Transforma uma <see cref="IList{T}"/> de <see cref="ValidationFailure"/> em uma <see cref="IList{T}"/> de <see cref="CustomValidationFailure"/>
        /// </summary>
        /// <param name="failures"><see cref="IList{T}"/> de <see cref="ValidationFailure"/></param>
        /// <returns><see cref="IList{T}"/> de <see cref="CustomValidationFailure"/></returns>
        public static IList<CustomValidationFailure> ToCustomValidationFailure(this IList<ValidationFailure> failures) =>
            failures.Select(f => new CustomValidationFailure(f.PropertyName, f.ErrorMessage)).ToList();
    }
}
