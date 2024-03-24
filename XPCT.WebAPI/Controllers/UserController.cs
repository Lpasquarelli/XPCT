using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.User;
using XPCT.Application.Results.Wallet;
using XPCT.Application.Services;
using XPCT.WebAPI.Models.Request.User;
using XPCT.WebAPI.Models.Request.Wallet;
using XPCT.WebAPI.Models.Response;

namespace XPCT.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra Usuario")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var prefix = "xpct.user.add";
            try
            {
                var result = await _userService.AddUser(request.Nome, request.Email, request.Operador);

                if (result.Status == AddUserStatus.Success)
                {
                    _logger.LogInformation($"User registred successfully.");
                    return Created("", new UserIdentifyerResponse(result.User.Id, result.Message));
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

        [HttpPost("GenerateToken")]
        [SwaggerOperation(Summary = "Gera um token para o usuário acessar o contexto definido para o mesmo na hora da criação (Operador/Cliente)")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserTokenResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> GenerateUserToken([FromBody] GenerateUserTokenRequest request)
        {
            var prefix = "xpct.user.add";
            try
            {
                var result = await _userService.GenerateUserTokenAsync(request.userId);

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
