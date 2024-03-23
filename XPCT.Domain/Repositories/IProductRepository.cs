using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;

namespace XPCT.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetProductAsync(Guid id);
        IEnumerable<Product> GetProductsAsync();
        Product AddProductAsync(Product product);
        Product UpdateProductAsync(Product product);
        Product ActivateProductAsync(Guid id);
        Product DeactivateProductAsync(Guid id);
    }
}
