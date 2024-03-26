using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.Products
{
    /// <summary>
    /// Status de Resultado para Deativação de Produtos
    /// </summary>
    public enum DisableProductStatus
    {
        Success,
        InternalError,
        ProductNotFound,
        ProductAlreadyDisabled,
        ErrorDisablingTheProduct
    }

    /// <summary>
    /// Resultado para Desativação de produtos
    /// </summary>
    public class DisableProductResult
    {
        /// <summary>
        /// <see cref="DisableProductStatus"/>
        /// </summary>
        public DisableProductStatus Status { get; private set; }
        
        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="IdentifyerResponse"/>
        /// </summary>
        public IdentifyerResponse? Product { get; private set; }

        /// <summary>
        /// Instancia um <see cref="DisableProductResult"/>
        /// </summary>
        /// <param name="status"><see cref="DisableProductStatus"/></param>
        /// <param name="message">mensagem de retorno</param>
        /// <param name="product"><see cref="IdentifyerResponse"/></param>
        public DisableProductResult(DisableProductStatus status, string message, IdentifyerResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="DisableProductResult"/></returns>
        public static DisableProductResult Success(Guid id) =>
            new(DisableProductStatus.Success, "success disabling the product", new IdentifyerResponse(id));
            
        /// <summary>
        /// Resultado de Erro interno 
        /// </summary>
        /// <param name="message">mensagem de resposta</param>
        /// <returns><see cref="DisableProductResult"/></returns>
        public static DisableProductResult InternalError(string message) =>
            new(DisableProductStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de Erro deabilitando o produto 
        /// </summary>
        /// <param name="message">mensagem de resposta</param>
        /// <returns><see cref="DisableProductResult"/></returns>
        public static DisableProductResult ErrorDisablingTheProduct(string message) =>
            new(DisableProductStatus.ErrorDisablingTheProduct, message, null);

        /// <summary>
        /// Resultado de Produto não encontrado
        /// </summary>
        /// <returns><see cref="DisableProductResult"/></returns>
        public static DisableProductResult ProductNotFound() =>
            new(DisableProductStatus.ProductNotFound, "Not a single product was found with the informed Id", null);


        /// <summary>
        /// Resultado de produto já desabilitado
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="DisableProductResult"/></returns>
        public static DisableProductResult ProductAlreadyDisabled(Guid id) =>
            new(DisableProductStatus.ProductAlreadyDisabled, "the product is already disabled", new IdentifyerResponse(id));
    }
}
