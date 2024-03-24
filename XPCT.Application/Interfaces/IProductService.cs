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
        GetProductsResult GetProducts();
        GetProductByIdResult GetProductById(Guid id);
        AddProductResult AddProduct(string name, double price, bool active, int daysToDue);
        UpdateProductResult UpdateProduct(Guid id, string name, double price, int daysToDue);
        EnableProductResult EnableProduct(Guid id);
        DisableProductResult DisableProduct(Guid id);
    }
}
