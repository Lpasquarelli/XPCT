using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.Products;
using XPCT.Application.Results.User;
using XPCT.Domain.Entities;
using XPCT.Domain.Repositories;

namespace XPCT.Application.Services
{
    /// <summary>
    /// Classe de serviço de Usuário
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IConfiguration _config;

        /// <summary>
        /// Instancia um <see cref="UserService"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger{UserService}"/></param>
        /// <param name="userRepository"><see cref="IUserRepository"/></param>
        /// <param name="walletRepository"><see cref="IWalletRepository"/></param>
        /// <param name="config"><see cref="IConfiguration"/></param>
        public UserService(ILogger<UserService> logger,
            IUserRepository userRepository,
            IWalletRepository walletRepository,
            IConfiguration config)
        {
            _logger = logger;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _config = config;
        }

        /// <inheritdoc/>
        public AddUserResult AddUser(string nome, string email, bool operador)
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

                    var addWallet = _walletRepository.CreateWallet(wallet);

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

        /// <inheritdoc/>
        public UserTokenResult GenerateUserToken(Guid userId)
        {
            try
            {
                var user = _userRepository.GetUserById(userId);

                if (user == null)
                    return UserTokenResult.UserNotFound();

                var dueDate = DateTime.UtcNow.AddMinutes(30);
                var token = GenerateToken(user, dueDate);

                if (string.IsNullOrEmpty(token))
                    return UserTokenResult.ErrorGeneratingUserToken();

                return UserTokenResult.Success(token, dueDate);

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return UserTokenResult.InternalError(ex.Message);
            }
        }

        /// <inheritdoc/>
        public GetUserWalletsUpcommingDueDateResult GetUserWalletsUpcommingDueDate()
        {
            try
            {
                var upcommingDueDateInvestments = _userRepository.GetUpCommingDueDatenvestmentsByUser();

                if (upcommingDueDateInvestments == null)
                    return GetUserWalletsUpcommingDueDateResult.ErrorGettingUserWalletsUpcommingDueDateStatus("an error occoured at getting the investments at upcomming due date");

                if (!upcommingDueDateInvestments.Any())
                    return GetUserWalletsUpcommingDueDateResult.NoContent();

                return GetUserWalletsUpcommingDueDateResult.Success(upcommingDueDateInvestments);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return GetUserWalletsUpcommingDueDateResult.InternalError(ex.Message);
            }
        }

        /// <summary>
        /// Gerar token do usuário
        /// </summary>
        /// <param name="user"><see cref="User"/></param>
        /// <param name="dueDate">data de expiração</param>
        /// <returns><see cref="string"/></returns>
        private string GenerateToken(User user, DateTime dueDate)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("JWT:Key").Value!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Operator ? "OPERATOR" : "CUSTOMER"),
                }),
                Expires = dueDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

    }
}
