using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Products
{
    public enum UpdateProductStatus
    {
        Success,
        ProductNotFound,
        InternalError,
        ErrorAtUpdateProduct
    }
    public class UpdateProductResult
    {
        public UpdateProductStatus Status { get; private set; }
        public string Message { get; private set; }
        public ProductResponse? Product { get; private set; }

        public UpdateProductResult(UpdateProductStatus status, string message, ProductResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        public static UpdateProductResult Success(ProductResponse product) =>
            new(UpdateProductStatus.Success, string.Empty, product);
        public static UpdateProductResult ProductNotFound() =>
            new(UpdateProductStatus.ProductNotFound, "Not a single product was found with the informed Id", null);
        public static UpdateProductResult InternalError(string message) =>
            new(UpdateProductStatus.InternalError, message, null);
        public static UpdateProductResult ErrorAtUpdateProduct(string message) =>
            new(UpdateProductStatus.ErrorAtUpdateProduct, message, null);
    }
}
