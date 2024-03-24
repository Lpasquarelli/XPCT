using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> Products = new();

        public Product GetProduct(Guid id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Product> GetProducts()
        {
            return Products.Where(x => x.Active);
        }
        public Product AddProduct(Product product)
        {
            Products.Add(product);
            return product;
        }
        public Product UpdateProduct(Product product)
        {
            var productFound = Products.First(x => x.Id == product.Id);
            var index = Products.IndexOf(productFound);
            Products[index] = product;
            return product;
        }
        public Product ActivateProduct(Guid id)
        {
            var productFound = Products.First(x => x.Id == id);
            var index = Products.IndexOf(productFound);
            productFound.Enable();
            Products[index] = productFound;
            return productFound;
        }
        public Product DeactivateProduct(Guid id)
        {
            var productFound = Products.First(x => x.Id == id);
            var index = Products.IndexOf(productFound);
            productFound.Disable();
            Products[index] = productFound;
            return productFound;
        }
    }
}
