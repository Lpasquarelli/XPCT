using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.User;
using XPCT.WebAPI.Models.Request.User;
using XPCT.WebAPI.Models.Response;
using XPCT.WebAPI.Validators;

namespace XPCT.WebAPI.Controllers
{
    /// <summary>
    /// Classe Controladora de Usuario
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IValidator<AddUserRequest> _addUserRequestValidator;
        private readonly IValidator<GenerateUserTokenRequest> _generateuserTokenRequestValidator;

        /// <summary>
        /// Instancia um <see cref="UserController"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger{UserController}"/></param>
        /// <param name="userService"><see cref="IUserService"/></param>
        /// <param name="addUserRequestValidator"><see cref="IValidator{T}"/> de <see cref="AddUserRequest"/></param>
        /// <param name="generateuserTokenRequestValidator"><see cref="IValidator{T}"/> de <see cref="GenerateUserTokenRequest"/></param>
        public UserController(ILogger<UserController> logger,
            IUserService userService,
            IValidator<AddUserRequest> addUserRequestValidator,
            IValidator<GenerateUserTokenRequest> generateuserTokenRequestValidator)
        {
            _logger = logger;
            _userService = userService;
            _addUserRequestValidator = addUserRequestValidator;
            _generateuserTokenRequestValidator = generateuserTokenRequestValidator;
        }

        /// <summary>
        /// Cadastra Usuario
        /// </summary>
        /// <param name="request"><see cref="AddUserRequest"/></param>
        /// <returns><see cref="UserIdentifyerResponse"/></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra Usuario")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult AddUser([FromBody] AddUserRequest request)
        {
            var prefix = "xpct.user.add";
            try
            {

                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _addUserRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = _userService.AddUser(request.Nome, request.Email, request.Operador);

                if (result.Status == AddUserStatus.Success)
                {
                    _logger.LogInformation($"User registred successfully.");
                    return Created("", new UserIdentifyerResponse(result.User!.Id, result.Message));
                }

                _logger.LogError($"Error registering the user || Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }

        /// <summary>
        /// Gera token de acesso
        /// </summary>
        /// <param name="request"><see cref="GenerateUserTokenRequest"/></param>
        /// <returns><see cref="UserTokenResponse"/></returns>
        [HttpPost("GenerateToken")]
        [SwaggerOperation(Summary = "Gera um token para o usuário acessar o contexto definido para o mesmo na hora da criação (Operador/Cliente)")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserTokenResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult GenerateUserToken([FromBody] GenerateUserTokenRequest request)
        {
            var prefix = "xpct.user.add";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _generateuserTokenRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = _userService.GenerateUserToken(request.userId);

                if (result.Status == UserTokenStatus.Success)
                {
                    _logger.LogInformation($"User token generated successfully.");
                    return Ok(new UserTokenResponse(result.Token!, result.DueDate!.Value));
                }

                _logger.LogError($"Error generating the user token|| Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }
    }
}
