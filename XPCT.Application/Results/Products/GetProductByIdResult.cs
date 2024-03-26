using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Products
{
    /// <summary>
    /// Status de Obter produto por Id
    /// </summary>
    public enum GetProductByIdStatus
    {
        Success,
        InternalError,
        ProductNotFound
    }

    /// <summary>
    /// Resultado de Obter produto por Id
    /// </summary>
    public class GetProductByIdResult
    {
        /// <summary>
        /// <see cref="GetProductByIdStatus"/>
        /// </summary>
        public GetProductByIdStatus Status { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="ProductResponse"/>
        /// </summary>
        public ProductResponse? Product { get;private set; }

        /// <summary>
        /// Instancia um <see cref="GetProductByIdResult"/>
        /// </summary>
        /// <param name="status"><see cref="GetProductByIdStatus"/></param>
        /// <param name="message">mensagem de retorno</param>
        /// <param name="product"><see cref="ProductResponse"/></param>
        public GetProductByIdResult(GetProductByIdStatus status, string message, ProductResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="product"><see cref="Domain.Entities.Product"/></param>
        /// <returns><see cref="GetProductByIdResult"/></returns>
        public static GetProductByIdResult Success(Product product) =>
            new(GetProductByIdStatus.Success, "Product search carried out successfully", new ProductResponse(product));

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="GetProductByIdResult"/></returns>
        public static GetProductByIdResult InternalError(string message) =>
            new(GetProductByIdStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de Produto não encontrado
        /// </summary>
        /// <returns><see cref="GetProductByIdResult"/></returns>
        public static GetProductByIdResult ProductNotFound() =>
            new(GetProductByIdStatus.ProductNotFound, "Not a single product was found with the informed Id", null);
    }
}
