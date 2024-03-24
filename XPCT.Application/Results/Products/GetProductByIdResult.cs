using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Products
{
    public enum GetProductByIdStatus
    {
        Success,
        InternalError,
        ProductNotFound
    }

    public class GetProductByIdResult
    {
        public GetProductByIdStatus Status { get; private set; }
        public string Message { get; private set; }
        public ProductResponse? Product { get;private set; }

        public GetProductByIdResult(GetProductByIdStatus status, string message, ProductResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        public static GetProductByIdResult Success(Product product) =>
            new(GetProductByIdStatus.Success, "Product search carried out successfully", new ProductResponse(product));

        public static GetProductByIdResult InternalError(string message) =>
            new(GetProductByIdStatus.InternalError, message, null);

        public static GetProductByIdResult ProductNotFound() =>
            new(GetProductByIdStatus.ProductNotFound, "Not a single product was found with the informed Id", null);
    }
}
