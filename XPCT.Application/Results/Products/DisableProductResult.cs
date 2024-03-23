using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.DTO.Response;

namespace XPCT.Application.Results.Products
{
    public enum DisableProductStatus
    {
        Success,
        InternalError,
        ProductNotFound,
        ProductAlreadyDisabled,
        ErrorDisablingTheProduct
    }

    public class DisableProductResult
    {
        public DisableProductStatus Status { get; private set; }
        public string Message { get; private set; }
        public IdentifyerResponse? Product { get; private set; }

        public DisableProductResult(DisableProductStatus status, string message, IdentifyerResponse? product)
        {
            Status = status;
            Message = message;
            Product = product;
        }

        public static DisableProductResult Success(Guid id) =>
            new(DisableProductStatus.Success, "success disabling the product", new IdentifyerResponse(id));
        public static DisableProductResult InternalError(string message) =>
            new(DisableProductStatus.InternalError, message, null);
        public static DisableProductResult ErrorDisablingTheProduct(string message) =>
            new(DisableProductStatus.ErrorDisablingTheProduct, message, null);
        public static DisableProductResult ProductNotFound() =>
            new(DisableProductStatus.ProductNotFound, "Not a single product was found with the informed Id", null);
        public static DisableProductResult ProductAlreadyDisabled(Guid id) =>
            new(DisableProductStatus.ProductAlreadyDisabled, "the product is already disabled", new IdentifyerResponse(id));
    }
}
