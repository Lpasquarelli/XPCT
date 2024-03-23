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
        public async Task GetProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = await productService.GetProductsAsync();

            // Assert
            result.Status.Should().Be(GetProductsStatus.Success);
        }

        [Fact]
        public async Task AddProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = await productService.AddProductAsync("", 0, true, 0);

            // Assert
            result.Status.Should().NotBe(AddProductStatus.Success);
        }

        [Fact]
        public async Task UpdateProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = await productService.UpdateProductAsync(Guid.NewGuid(), "TESTE", 10, 10);

            // Assert
            result.Status.Should().NotBe(UpdateProductStatus.Success);
        }

        [Fact]
        public async Task DisableProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = await productService.DisableProductAsync(Guid.NewGuid());

            // Assert
            result.Status.Should().NotBe(DisableProductStatus.Success);
        }

        [Fact]
        public async Task EnableProductAsync_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var productService = new ProductService(_loggerMock.Object, _productRepositoryMock.Object);

            // Act
            var result = await productService.EnableProductAsync(Guid.NewGuid());

            // Assert
            result.Status.Should().NotBe(EnableProductStatus.Success);
        }
    }
}
