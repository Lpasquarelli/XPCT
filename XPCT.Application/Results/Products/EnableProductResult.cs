using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;
using XPCT.Domain.Entities;

namespace XPCT.Application.Results.Products
{
    public enum EnableProductStatus
    {
        Success,
        InternalError,
        ProductNotFound,
        ProductAlreadyEnabled,
        ErrorEnablingTheProduct
    }

    public class EnableProductResult
    {
        public EnableProductStatus Status { get; private set; }
        public string Message { get; private set; }
        public IdentifyerResponse? Product { get; private set; }

        public EnableProductResult(EnableProductStatus status, string message, IdentifyerResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        public static EnableProductResult Success(Guid id) =>
            new(EnableProductStatus.Success, "success enabling the product", new IdentifyerResponse(id));

        public static EnableProductResult InternalError(string message) =>
            new(EnableProductStatus.InternalError, message, null);
        public static EnableProductResult ErrorEnablingTheProduct(string message) =>
            new(EnableProductStatus.ErrorEnablingTheProduct, message, null);

        public static EnableProductResult ProductNotFound() =>
            new(EnableProductStatus.ProductNotFound, "Not a single product was found with the informed Id", null);

        public static EnableProductResult ProductAlreadyEnabled(Guid id) =>
            new(EnableProductStatus.ProductAlreadyEnabled, "the product is already enabled", new IdentifyerResponse(id));
    }
}

