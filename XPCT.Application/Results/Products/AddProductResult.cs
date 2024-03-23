using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Products
{
    public enum AddProductStatus
    {
        Success,
        InternalError,
        ErrorInsertingProduct,
        ProductDescriptionAlreadyExists
    }

    public class AddProductResult
    {
        public AddProductStatus Status { get; private set; }
        public string Message { get; private set; }
        public ProductResponse? Product { get; private set; }

        public AddProductResult(AddProductStatus status, string message, ProductResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        public static AddProductResult Success(ProductResponse product) =>
            new(AddProductStatus.Success, "Product registered successfully", product);

        public static AddProductResult InternalError(string message) =>
            new(AddProductStatus.InternalError, message, null);

        public static AddProductResult ErrorInsertingProduct(string message) =>
            new(AddProductStatus.ErrorInsertingProduct, message, null);
        public static AddProductResult ProductDescriptionAlreadyExists(string message) =>
            new(AddProductStatus.ProductDescriptionAlreadyExists, message, null);
    }
}
