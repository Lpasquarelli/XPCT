using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XPCT.Application.DTO.Response;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.Products;
using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Application.Services
{
    /// <summary>
    /// Classe de Serviço de Produto
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Instancia um <see cref="ProductService"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger{ProductService}"/></param>
        /// <param name="productRepository"><see cref="IProductRepository"/></param>
        public ProductService(ILogger<ProductService> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        /// <inheritdoc/>
        public GetProductsResult GetProducts()
        {
            try
            {
                _logger.LogInformation("Attempt to search the active products");
                var products = _productRepository.GetProducts();

                if (products == null)
                {
                    _logger.LogError("an error occoured at serching products");
                    return GetProductsResult.ErrorSearchingProducts("an error occoured at serching products");
                }

                _logger.LogInformation("Attempt to search the active products done successfuly.");
                return GetProductsResult.Success(products);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: { ex.StackTrace} || Error Message: { ex.Message}.");
                return GetProductsResult.InternalError(ex.Message);
            }
        }

        /// <inheritdoc/>
        public GetProductByIdResult GetProductById(Guid id)
        {
            try
            {
                _logger.LogInformation("Attempt to search the product");
                var product = _productRepository.GetProduct(id);

                if (product == null)
                {
                    _logger.LogError("an error occoured at serching the product");
                    return GetProductByIdResult.ProductNotFound();
                }

                _logger.LogInformation("Attempt to search the product done successfuly.");
                return GetProductByIdResult.Success(product);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return GetProductByIdResult.InternalError(ex.Message);
            }
        }

        /// <inheritdoc/>
        public AddProductResult AddProduct(string name, double price, bool active, int daysToDue)
        {
            try
            {
                _logger.LogInformation("Attempt to register the product");

                var product = new Product(name, price, active, daysToDue);

                var addProduct = _productRepository.AddProduct(product);

                if (addProduct == null)
                {
                    _logger.LogError("an error occoured inserting the product");
                    return AddProductResult.ErrorInsertingProduct("an error occoured inserting the product");
                }

                _logger.LogInformation("Attempt to register the product done successfuly.");
                return AddProductResult.Success(new ProductResponse(addProduct));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return AddProductResult.InternalError(ex.Message);
            }
        }

        /// <inheritdoc/>
        public UpdateProductResult UpdateProduct(Guid id, string name, double price, int daysToDue)
        {
            try
            {
                _logger.LogInformation("Attempt to register the product");

                var getProductById = _productRepository.GetProduct(id);

                if (getProductById == null)
                {
                    _logger.LogError($"Product not found with Id: {id}");
                    return UpdateProductResult.ProductNotFound();
                }

                var product = new Product(id, name, price, daysToDue);

                getProductById.Update(product);

                var updateProduct = _productRepository.UpdateProduct(getProductById);

                if(updateProduct == null)
                {
                    _logger.LogError($"An Error occoured due attempt to update the product");
                    return UpdateProductResult.ErrorAtUpdateProduct("An Error occoured due attempt to update the product");
                }

                _logger.LogInformation("Attempt to update the product done successfuly.");
                return UpdateProductResult.Success(new ProductResponse(updateProduct));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return UpdateProductResult.InternalError(ex.Message);
            }
        }

        /// <inheritdoc/>
        public EnableProductResult EnableProduct(Guid id)
        {
            try
            {
                _logger.LogInformation("Attempt to enable the product");

                var getProductById = _productRepository.GetProduct(id);

                if (getProductById == null)
                {
                    _logger.LogError($"Product not found with Id: {id}");
                    return EnableProductResult.ProductNotFound();
                }

                if (getProductById.Active)
                    return EnableProductResult.ProductAlreadyEnabled(id);

                var updateProduct = _productRepository.ActivateProduct(id);

                if (updateProduct == null)
                {
                    _logger.LogError($"An Error occoured due attempt to enable the product");
                    return EnableProductResult.ErrorEnablingTheProduct("An Error occoured due attempt to enable the product");
                }

                _logger.LogInformation("Attempt to enable the product done successfuly.");
                return EnableProductResult.Success(id);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return EnableProductResult.InternalError(ex.Message);
            }
        }

        /// <inheritdoc/>
        public DisableProductResult DisableProduct(Guid id)
        {
            try
            {
                _logger.LogInformation("Attempt to disable the product");

                var getProductById = _productRepository.GetProduct(id);

                if (getProductById == null)
                {
                    _logger.LogError($"Product not found with Id: {id}");
                    return DisableProductResult.ProductNotFound();
                }

                if (!getProductById.Active)
                    return DisableProductResult.ProductAlreadyDisabled(id);

                var updateProduct = _productRepository.DeactivateProduct(id);

                if (updateProduct == null)
                {
                    _logger.LogError($"An Error occoured due attempt to disable the product");
                    return DisableProductResult.ErrorDisablingTheProduct("An Error occoured due attempt to disable the product");
                }

                _logger.LogInformation("Attempt to disable the product done successfuly.");
                return DisableProductResult.Success(id);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return DisableProductResult.InternalError(ex.Message);
            }
        }
    }
}
