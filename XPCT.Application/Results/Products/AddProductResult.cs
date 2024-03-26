using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.Products
{
    /// <summary>
    /// Status de criação de produto
    /// </summary>
    public enum AddProductStatus
    {
        Success,
        InternalError,
        ErrorInsertingProduct,
        ProductDescriptionAlreadyExists
    }

    /// <summary>
    /// Classe de resultado de criação de produto
    /// </summary>
    public class AddProductResult
    {
        /// <summary>
        /// <see cref="AddProductStatus"/>
        /// </summary>
        public AddProductStatus Status { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="ProductResponse"/>
        /// </summary>
        public ProductResponse? Product { get; private set; }

        /// <summary>
        /// Instancia um <see cref="AddProductResult"/>
        /// </summary>
        /// <param name="status"><see cref="AddProductStatus"/></param>
        /// <param name="message">mensagem de retorno</param>
        /// <param name="product"><see cref="ProductResponse"/></param>
        public AddProductResult(AddProductStatus status, string message, ProductResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="product"><see cref="ProductResponse"/></param>
        /// <returns><see cref="AddProductResult"/></returns>
        public static AddProductResult Success(ProductResponse product) =>
            new(AddProductStatus.Success, "Product registered successfully", product);

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="AddProductResult"/></returns>
        public static AddProductResult InternalError(string message) =>
            new(AddProductStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de Erro ao inserir produtos
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="AddProductResult"/></returns>
        public static AddProductResult ErrorInsertingProduct(string message) =>
            new(AddProductStatus.ErrorInsertingProduct, message, null);

        /// <summary>
        /// Resultado de Descricao do produto já existe
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="AddProductResult"/></returns>
        public static AddProductResult ProductDescriptionAlreadyExists(string message) =>
            new(AddProductStatus.ProductDescriptionAlreadyExists, message, null);
    }
}
