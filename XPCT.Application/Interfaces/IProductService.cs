using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.Results.Products;
using XPCT.Domain.Entities;

namespace XPCT.Application.Interfaces
{
    public interface IProductService
    {
        Task<GetProductsResult> GetProductsAsync();
        Task<GetProductByIdResult> GetProductByIdAsync(Guid id);
        Task<AddProductResult> AddProductAsync(string name, double price, bool active, int daysToDue);
        Task<UpdateProductResult> UpdateProductAsync(Guid id, string name, double price, int daysToDue);
        Task<EnableProductResult> EnableProductAsync(Guid id);
        Task<DisableProductResult> DisableProductAsync(Guid id);
    }
}
