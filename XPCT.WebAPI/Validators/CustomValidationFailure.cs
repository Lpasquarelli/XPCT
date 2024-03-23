namespace XPCT.WebAPI.Validators
{
    public class CustomValidationFailure
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public CustomValidationFailure(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}
