using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio de Produto
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        public List<Product> Products = new();

        /// <inheritdoc/>
        public Product GetProduct(Guid id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }
        /// <inheritdoc/>
        public IEnumerable<Product> GetProducts()
        {
            return Products.Where(x => x.Active);
        }
        /// <inheritdoc/>
        public Product AddProduct(Product product)
        {
            Products.Add(product);
            return product;
        }
        /// <inheritdoc/>
        public Product UpdateProduct(Product product)
        {
            var productFound = Products.First(x => x.Id == product.Id);
            var index = Products.IndexOf(productFound);
            Products[index] = product;
            return product;
        }
        /// <inheritdoc/>
        public Product ActivateProduct(Guid id)
        {
            var productFound = Products.First(x => x.Id == id);
            var index = Products.IndexOf(productFound);
            productFound.Enable();
            Products[index] = productFound;
            return productFound;
        }
        /// <inheritdoc/>
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
