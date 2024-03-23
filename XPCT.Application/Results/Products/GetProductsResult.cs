using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Products
{
    public enum GetProductsStatus
    {
        Success,
        InternalError,
        ErrorSearchingProducts
    }

    public class GetProductsResult
    {
        public GetProductsStatus Status { get; private set; }
        public string Message { get; private set; }
        public IEnumerable<ProductResponse>? Products { get;private set; }

        public GetProductsResult(GetProductsStatus status, string message, IEnumerable<ProductResponse>? products)
        {
            Status = status;
            Message = message;
            Products = products;
        }

        public static GetProductsResult Success(IEnumerable<Product> products) =>
            new(GetProductsStatus.Success, "Product search carried out successfully", ProductResponse.ToResponseList(products));

        public static GetProductsResult InternalError(string message) =>
            new(GetProductsStatus.InternalError, message, null);

        public static GetProductsResult ErrorSearchingProducts(string message) =>
            new(GetProductsStatus.ErrorSearchingProducts, message, null);
    }
}
