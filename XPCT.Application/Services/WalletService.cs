using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.Products;
using XPCT.Application.Results.Wallet;
using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly ILogger<WalletService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;
        public WalletService(ILogger<WalletService> logger,
            IProductRepository productRepository,
            IWalletRepository walletRepository,
            IUserRepository userRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _walletRepository = walletRepository;
            _userRepository = userRepository;

        }

        public async Task<BuyInvestmentResult> BuyInvestmentAsync(Guid userId, double quantity, Guid productId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);

                if (user == null)
                    return BuyInvestmentResult.UserNotFound();

                var searchProduct = _productRepository.GetProductAsync(productId);

                if (searchProduct == null)
                    return BuyInvestmentResult.ErrorSearchingProduct("product was not found");

                var getWallet = _walletRepository.GetWalletByIdAsync(user.Wallet!.Id);

                if(getWallet == null)
                    return BuyInvestmentResult.WalletNotFound();

                var investment = new Investment(searchProduct, quantity, DateTime.Now);

                var buyInvestment = _walletRepository.AddInvestmentToWallet(user.Wallet.Id, investment);

                if (buyInvestment == null)
                    return BuyInvestmentResult.ErrorBuyingTheProduct();

                return BuyInvestmentResult.Success(buyInvestment.Id);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BuyInvestmentResult.InternalError(ex.Message);
            }
        }

        public async Task<SellInvestmentResult> SellInvestmentAsync(Guid userId, double quantity, Guid productId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);

                if (user == null)
                    return SellInvestmentResult.UserNotFound();

                var searchProduct = _productRepository.GetProductAsync(productId);

                if (searchProduct == null)
                    return SellInvestmentResult.ErrorSearchingProduct("product was not found");

                if (!user.Wallet!.Investments.Any(x => x.Product!.Id == productId))
                    return SellInvestmentResult.InvestmentNotFoundOnWallet();

                var investment = user.Wallet.Investments.First(x => x.Product!.Id == productId);

                if (investment.Quantity < quantity)
                    return SellInvestmentResult.NotEnoughQuantityOnWallet();

                var sellInvestment = _walletRepository.SellInvestment(user.Wallet.Id, investment.Product!.Id, quantity);

                if (sellInvestment == null)
                    return SellInvestmentResult.ErrorSellingTheProduct();

                return SellInvestmentResult.Success(sellInvestment.Id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return SellInvestmentResult.InternalError(ex.Message);
            }
        }
    }
}
