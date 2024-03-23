using FluentValidation.Results;

namespace XPCT.WebAPI.Validators
{
    public static class ValidationFailureExtesions
    {
        public static IList<CustomValidationFailure> ToCustomValidationFailure(this IList<ValidationFailure> failures) =>
            failures.Select(f => new CustomValidationFailure(f.PropertyName, f.ErrorMessage)).ToList();
    }
}
