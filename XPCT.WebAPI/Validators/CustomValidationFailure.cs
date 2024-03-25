namespace XPCT.WebAPI.Validators
{
    /// <summary>
    /// Classe de falhas de validação customizadas
    /// </summary>
    public class CustomValidationFailure
    {
        /// <summary>
        /// mensagem de erro
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// nome da propriedade
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// Instancia um <see cref="CustomValidationFailure"/>
        /// </summary>
        /// <param name="errorMessage">mensagem de erro</param>
        /// <param name="propertyName">nome da propriedade</param>
        public CustomValidationFailure(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}
