using XPCT.Application.Results.Products;

namespace XPCT.Application.Interfaces
{
    /// <summary>
    /// Interface de Serviço de Produtos
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Obter Produtos
        /// </summary>
        /// <returns><see cref="GetProductsResult"/></returns>
        GetProductsResult GetProducts();

        /// <summary>
        /// Obter produtos por Id
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="GetProductByIdResult"/></returns>
        GetProductByIdResult GetProductById(Guid id);

        /// <summary>
        /// Criar novo produto
        /// </summary>
        /// <param name="name">nome do produto</param>
        /// <param name="price">preço do produto</param>
        /// <param name="active">flag de ativação do produto</param>
        /// <param name="daysToDue">dias para o vencimento do produto após a compra</param>
        /// <returns><see cref="AddProductResult"/></returns>
        AddProductResult AddProduct(string name, double price, bool active, int daysToDue);

        /// <summary>
        /// Editar Produto
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <param name="name">nome do produto</param>
        /// <param name="price">preço do produto</param>
        /// <param name="daysToDue">dias para o vencimento do produto após a compra</param>
        /// <returns></returns>
        UpdateProductResult UpdateProduct(Guid id, string name, double price, int daysToDue);

        /// <summary>
        /// Ativar Produto
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="EnableProductResult"/></returns>
        EnableProductResult EnableProduct(Guid id);

        /// <summary>
        /// Desativar produto
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <returns><see cref="DisableProductResult"/></returns>
        DisableProductResult DisableProduct(Guid id);
    }
}
