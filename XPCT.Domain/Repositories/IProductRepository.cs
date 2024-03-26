using XPCT.Domain.Entities;

namespace XPCT.Domain.Repositories
{
    /// <summary>
    /// Interface de Repositorio de Produto
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Consulta produto por id
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="Product"/></returns>
        Product GetProduct(Guid id);

        /// <summary>
        /// Consultar Produtos
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> de <see cref="Product"/></returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Cadastra  Produto
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        /// <returns><see cref="Product"/></returns>
        Product AddProduct(Product product);

        /// <summary>
        /// Altera Produto
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        /// <returns><see cref="Product"/></returns>
        Product UpdateProduct(Product product);

        /// <summary>
        /// Ativa produto
        /// </summary>
        /// <param name="id">Codigo do produto</param>
        /// <returns><see cref="Product"/></returns>
        Product ActivateProduct(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="Product"/></returns>
        Product DeactivateProduct(Guid id);
    }
}
