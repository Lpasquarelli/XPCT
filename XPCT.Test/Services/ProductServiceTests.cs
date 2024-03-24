using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.Services;
using XPCT.Application.Results.Products;
using XPCT.Domain.Repositories;
using Xunit;
using XPCT.Domain.Entities;
using FluentAssertions;

namespace XPCT.Test.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<ProductService> _productServiceMock;
        private readonly Mock<ILogger<ProductService>> _loggerMock;
        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productServiceMock = new Mock<ProductService>();
            _loggerMock = new Mock<ILogger<ProductService>>();
        }


        [Fact]
        public void GetProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = productService.GetProducts();

            // Assert
            result.Status.Should().Be(GetProductsStatus.Success);
        }

        [Fact]
        public void AddProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = productService.AddProduct("", 0, true, 0);

            // Assert
            result.Status.Should().NotBe(AddProductStatus.Success);
        }

        [Fact]
        public void UpdateProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = productService.UpdateProduct(Guid.NewGuid(), "TESTE", 10, 10);

            // Assert
            result.Status.Should().NotBe(UpdateProductStatus.Success);
        }

        [Fact]
        public void DisableProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = productService.DisableProduct(Guid.NewGuid());

            // Assert
            result.Status.Should().NotBe(DisableProductStatus.Success);
        }

        [Fact]
        public void EnableProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = productService.EnableProduct(Guid.NewGuid());

            // Assert
            result.Status.Should().NotBe(EnableProductStatus.Success);
        }
    }
}
