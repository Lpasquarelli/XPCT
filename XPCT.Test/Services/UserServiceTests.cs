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
using XPCT.Application.Results.User;
using Microsoft.Extensions.Configuration;

namespace XPCT.Test.Services
{
    public class UserServiceTests
    {
        private readonly Mock<UserService> _userServiceMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IWalletRepository> _walletRepositoryMock;
        private readonly Mock<IConfiguration> _configMock;
        private readonly Mock<ILogger<UserService>> _loggerMock;
        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _walletRepositoryMock = new Mock<IWalletRepository>();
            _configMock = new Mock<IConfiguration>();
            _userServiceMock = new Mock<UserService>();
            _loggerMock = new Mock<ILogger<UserService>>();
        }

        [Fact]
        public void AddUser_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var userService = new UserService(_loggerMock.Object, _userRepositoryMock.Object, _walletRepositoryMock.Object, _configMock.Object);
            
            // Act
            var result = userService.AddUser("Leonardo","teste@teste.com",false);

            // Assert
            result.Status.Should().NotBe(AddUserStatus.Success);
        }

        [Fact]
        public void GenerateUserToken_InvalidInput_ReturnsErrorResult()
        {
            // Arrange
            var userService = new UserService(_loggerMock.Object, _userRepositoryMock.Object, _walletRepositoryMock.Object, _configMock.Object);

            // Act
            var result = userService.GenerateUserToken(Guid.NewGuid());

            // Assert
            result.Status.Should().NotBe(UserTokenStatus.Success);
        }
    }
}
