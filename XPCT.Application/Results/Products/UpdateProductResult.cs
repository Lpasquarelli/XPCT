using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.Products
{
    /// <summary>
    /// Status de Resultado de alteração de um produto
    /// </summary>
    public enum UpdateProductStatus
    {
        Success,
        ProductNotFound,
        InternalError,
        ErrorAtUpdateProduct
    }

    /// <summary>
    /// Resultado de alteração de produto
    /// </summary>
    public class UpdateProductResult
    {
        /// <summary>
        /// <see cref="UpdateProductStatus"/>
        /// </summary>
        public UpdateProductStatus Status { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="ProductResponse"/>
        /// </summary>
        public ProductResponse? Product { get; private set; }

        /// <summary>
        /// Instancia um <see cref="UpdateProductResult"/>
        /// </summary>
        /// <param name="status"><see cref="UpdateProductStatus"/></param>
        /// <param name="message">Mensagem de retorno</param>
        /// <param name="product"><see cref="ProductResponse"/></param>
        public UpdateProductResult(UpdateProductStatus status, string message, ProductResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="product"><see cref="ProductResponse"/></param>
        /// <returns><see cref="UpdateProductResult"/></returns>
        public static UpdateProductResult Success(ProductResponse product) =>
            new(UpdateProductStatus.Success, string.Empty, product);

        /// <summary>
        /// Resultado de Produto nao encontrado
        /// </summary>
        /// <returns><see cref="UpdateProductResult"/></returns>
        public static UpdateProductResult ProductNotFound() =>
            new(UpdateProductStatus.ProductNotFound, "Not a single product was found with the informed Id", null);

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="UpdateProductResult"/></returns>
        public static UpdateProductResult InternalError(string message) =>
            new(UpdateProductStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de erro ao editar produto
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="UpdateProductResult"/></returns>
        public static UpdateProductResult ErrorAtUpdateProduct(string message) =>
            new(UpdateProductStatus.ErrorAtUpdateProduct, message, null);
    }
}
