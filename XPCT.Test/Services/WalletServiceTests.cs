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
using XPCT.Application.Results.Wallet;

namespace XPCT.Test.Services
{
    public class WalletServiceTests
    {
        private readonly Mock<WalletService> _walletServiceMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IWalletRepository> _walletRepositoryMock;
        private readonly Mock<ILogger<WalletService>> _loggerMock;
        public WalletServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _walletRepositoryMock = new Mock<IWalletRepository>();
            _walletServiceMock = new Mock<WalletService>();
            _loggerMock = new Mock<ILogger<WalletService>>();
        }


        [Fact]
        public void BuyInvestment_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var walletService = new WalletService(_loggerMock.Object, _productRepositoryMock.Object, _walletRepositoryMock.Object, _userRepositoryMock.Object);
            

            // Act
            var result = walletService.BuyInvestment(Guid.NewGuid(), 10, Guid.NewGuid());

            // Assert
            result.Status.Should().NotBe(BuyInvestmentStatus.Success);
        }

        [Fact]
        public void SellInvestment_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var walletService = new WalletService(_loggerMock.Object, _productRepositoryMock.Object, _walletRepositoryMock.Object, _userRepositoryMock.Object);

            // Act
            var result = walletService.SellInvestment(Guid.NewGuid(), 10, Guid.NewGuid());

            // Assert
            result.Status.Should().NotBe(SellInvestmentStatus.Success);
        }

        [Fact]
        public void GetWalletExtract_InvalidInput_ReturnsSuccess()
        {
            // Arrange
            var walletService = new WalletService(_loggerMock.Object, _productRepositoryMock.Object, _walletRepositoryMock.Object, _userRepositoryMock.Object);

            var user = new User("Leonardo", "leonardo.pasquarellif@gmail.com", false);
            var wallet = new Wallet();
            user.LoadWallet(wallet);
            // Act
            var result = walletService.GetWalletExtract(user.Id, null);

            // Assert
            result.Status.Should().NotBe(GetWalletExtractStatus.Success);
        }

        [Fact]
        public void GetWalletInvestments_InvalidInput_ReturnsSuccess()
        {
            // Arrange
            var walletService = new WalletService(_loggerMock.Object, _productRepositoryMock.Object, _walletRepositoryMock.Object, _userRepositoryMock.Object);

            var user = new User("Leonardo", "leonardo.pasquarellif@gmail.com", false);
            var wallet = new Wallet();
            user.LoadWallet(wallet);
            // Act
            var result = walletService.GetWalletInvestments(user.Id);

            // Assert
            result.Status.Should().NotBe(GetWalletInvestmentsStatus.Success);
        }
    }
}
