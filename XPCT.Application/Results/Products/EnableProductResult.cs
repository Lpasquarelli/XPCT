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
    /// Status de resultado de ativação do produto
    /// </summary>
    public enum EnableProductStatus
    {
        Success,
        InternalError,
        ProductNotFound,
        ProductAlreadyEnabled,
        ErrorEnablingTheProduct
    }

    /// <summary>
    /// Resultado de Ativação de produto
    /// </summary>
    public class EnableProductResult
    {
        /// <summary>
        /// <see cref="EnableProductStatus"/>
        /// </summary>
        public EnableProductStatus Status { get; private set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// <see cref="IdentifyerResponse"/>
        /// </summary>
        public IdentifyerResponse? Product { get; private set; }

        /// <summary>
        /// Instancia um <see cref="EnableProductResult"/>
        /// </summary>
        /// <param name="status"><see cref="EnableProductStatus"/></param>
        /// <param name="message">mensagem de retorno</param>
        /// <param name="product"><see cref="IdentifyerResponse"/></param>
        public EnableProductResult(EnableProductStatus status, string message, IdentifyerResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        /// <summary>
        /// Resultado de Sucesso
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="EnableProductResult"/></returns>
        public static EnableProductResult Success(Guid id) =>
            new(EnableProductStatus.Success, "success enabling the product", new IdentifyerResponse(id));

        /// <summary>
        /// Resultado de Erro Interno
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="EnableProductResult"/></returns>
        public static EnableProductResult InternalError(string message) =>
            new(EnableProductStatus.InternalError, message, null);

        /// <summary>
        /// Resultado de Erro ativando o produto
        /// </summary>
        /// <param name="message">mensagem de retorno</param>
        /// <returns><see cref="EnableProductResult"/></returns>
        public static EnableProductResult ErrorEnablingTheProduct(string message) =>
            new(EnableProductStatus.ErrorEnablingTheProduct, message, null);

        /// <summary>
        /// Resultado de produto não encontrado
        /// </summary>
        /// <returns><see cref="EnableProductResult"/></returns>
        public static EnableProductResult ProductNotFound() =>
            new(EnableProductStatus.ProductNotFound, "Not a single product was found with the informed Id", null);

        /// <summary>
        /// Resultado de Produto já Ativo
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="EnableProductResult"/></returns>
        public static EnableProductResult ProductAlreadyEnabled(Guid id) =>
            new(EnableProductStatus.ProductAlreadyEnabled, "the product is already enabled", new IdentifyerResponse(id));
    }
}

