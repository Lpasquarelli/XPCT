using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Products
{
    /// <summary>
    /// Status de Resultado de Obter produtos
    /// </summary>
    public enum GetProductsStatus
    {
        Success,
        InternalError,
        ErrorSearchingProducts
    }

    /// <summary>
    /// Resultado de Obter produtos
    /// </summary>
    public class GetProductsResult
    {
        /// <summary>
        /// <see cref="GetProductsStatus"/>
        /// </summary>
        public GetProductsStatus Status { get; private set; }
        
        /// <summary>
        /// mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="IEnumerable{T}"/> de <see cref="ProductResponse"/>
        /// </summary>
        public IEnumerable<ProductResponse>? Products { get;private set; }

        /// <summary>
        /// Instancia um <see cref="GetProductsResult"/>
        /// </summary>
        /// <param name="status"><see cref="GetProductsStatus"/></param>
        /// <param name="message">mensagem de retorno</param>
        /// <param name="products"><see cref="IEnumerable{T}"/> de <see cref="ProductResponse"/></param>
        public GetProductsResult(GetProductsStatus status, string message, IEnumerable<ProductResponse>? products)
        {
            Status = status;
            Message = message;
            Products = products;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="products"><see cref="IEnumerable{T}"/> de <see cref="Product"/></param>
        /// <returns><see cref="GetProductsResult"/></returns>
        public static GetProductsResult Success(IEnumerable<Product> products) =>
            new(GetProductsStatus.Success, "Product search carried out successfully", ProductResponse.ToResponseList(products));

        /// <summary>
        /// Resultado de Erro Interno 
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="GetProductsResult"/></returns>
        public static GetProductsResult InternalError(string message) =>
            new(GetProductsStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de Erro procurando pelos produtos
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="GetProductsResult"/></returns>
        public static GetProductsResult ErrorSearchingProducts(string message) =>
            new(GetProductsStatus.ErrorSearchingProducts, message, null);
    }
}
