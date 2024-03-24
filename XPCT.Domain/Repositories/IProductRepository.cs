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
        Product GetProduct(Guid id);
        IEnumerable<Product> GetProducts();
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        Product ActivateProduct(Guid id);
        Product DeactivateProduct(Guid id);
    }
}
