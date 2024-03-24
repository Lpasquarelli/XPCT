using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.Products;
using XPCT.Application.Results.User;
using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;
        public UserService(ILogger<UserService> logger,
            IUserRepository userRepository,
            IWalletRepository walletRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _walletRepository = walletRepository;

        }

        public async Task<AddUserResult> AddUser(string nome, string email, bool operador)
        {
            try
            {
                _logger.LogInformation("Attempt to search the active products");
                var verifyEmail = _userRepository.GetUserByEmail(email);

                if (verifyEmail != null)
                {
                    _logger.LogError("this email is in use");
                    return AddUserResult.EmailAlreadyUsing();
                }

                var user = new User(nome, email, operador);

                var addUser = _userRepository.CreateUser(user);

                if (addUser == null) 
                {
                    _logger.LogError("an error occoured at creating user");
                    return AddUserResult.ErrorCreatingUser("an error occoured at creating user");
                }

                if (!operador)
                {
                    var wallet = new Wallet();

                    var addWallet = _walletRepository.CreateWalletAsync(wallet);

                    if(addWallet == null)
                        return AddUserResult.ErrorCreatingUser("the user was created but the wallet don't");


                    var addWalletToUser = _userRepository.CreateUserWallet(user.Id, wallet);

                    if(!addWalletToUser)
                        return AddUserResult.ErrorCreatingUser("sorry we can't sincronize the user and the wallet");
                }

                _logger.LogInformation("Attempt to create user done successfuly.");
                return AddUserResult.Success(user.Id);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return AddUserResult.InternalError(ex.Message);
            }
        }
    }
}
