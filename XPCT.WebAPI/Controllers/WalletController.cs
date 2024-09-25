using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.Wallet;
using XPCT.WebAPI.Models.Request.Wallet;
using XPCT.WebAPI.Models.Response;
using XPCT.WebAPI.Validators;

namespace XPCT.WebAPI.Controllers
{
    /// <summary>
    /// Classe Controladora de Carteira
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WalletController : Controller
    {
        private readonly ILogger<WalletController> _logger;
        private readonly IWalletService _walletService;
        private readonly IValidator<BuyInvestmentsRequest> _buyInvestmentsRequestValidator;
        private readonly IValidator<SellInvestmentsRequest> _sellInvestmentsRequestValidator;

        /// <summary>
        /// Instancia um <see cref="WalletController"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger{WalletController}"/></param>
        /// <param name="walletService"><see cref="IWalletService"/></param>
        /// <param name="buyInvestmentsRequestValidator"><see cref="IValidator{T}"/> de <see cref="BuyInvestmentsRequest"/></param>
        /// <param name="sellInvestmentsRequestValidator"><see cref="IValidator{T}"/> de <see cref="SellInvestmentsRequest"/></param>
        public WalletController(ILogger<WalletController> logger,
            IWalletService walletService,
            IValidator<BuyInvestmentsRequest> buyInvestmentsRequestValidator,
            IValidator<SellInvestmentsRequest> sellInvestmentsRequestValidator)
        {
            _logger = logger;
            _walletService = walletService;
            _buyInvestmentsRequestValidator = buyInvestmentsRequestValidator;
            _sellInvestmentsRequestValidator = sellInvestmentsRequestValidator;

        }

        /// <summary>
        /// Compra investimento
        /// </summary>
        /// <param name="request"><see cref="BuyInvestmentsRequest"/></param>
        /// <returns><see cref="WalletIdentifyerResponse"/></returns>
        [HttpPost("buy")]
        [Authorize(Roles = "Gerente")]
        [SwaggerOperation(Summary = "Compra de Investimento")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(WalletIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult BuyInvestments([FromBody] BuyInvestmentsRequest request)
        {
            var prefix = "xpct.wal.buy";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _buyInvestmentsRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = _walletService.BuyInvestment(request.UserId, request.Quantity, request.ProductId);

                if (result.Status == BuyInvestmentStatus.Success)
                {
                    _logger.LogInformation($"Product purchased successfully.");
                    return Ok(new WalletIdentifyerResponse(result.Wallet!.Id, result.Message));
                }

                _logger.LogError($"Error purchasing the product || Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }

        /// <summary>
        /// Vende investimento
        /// </summary>
        /// <param name="request"><see cref="SellInvestmentsRequest"/></param>
        /// <returns><see cref="WalletIdentifyerResponse"/></returns>
        [HttpPost("sell")]
        [Authorize(Roles = "CUSTOMER")]
        [SwaggerOperation(Summary = "Venda de Investimento")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(WalletIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult SellInvestments([FromBody] SellInvestmentsRequest request)
        {
            var prefix = "xpct.wal.sell";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _sellInvestmentsRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = _walletService.SellInvestment(request.UserId, request.Quantity, request.ProductId);

                if (result.Status == SellInvestmentStatus.Success)
                {
                    _logger.LogInformation($"Product sold successfully.");
                    return Ok(new WalletIdentifyerResponse(result.Wallet!.Id, result.Message));
                }

                _logger.LogError($"Error selling the product || Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }

        /// <summary>
        /// Obtem Extrato
        /// </summary>
        /// <param name="userId">código do usuário</param>
        /// <param name="productId">código do produto</param>
        /// <returns><see cref="WalletExtractResponse"/></returns>
        [HttpGet("extract/{userId}")]
        [Authorize(Roles = "CUSTOMER")]
        [SwaggerOperation(Summary = "Obter extrato da carteira do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(WalletExtractResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult GetWalletExtract([FromRoute] Guid userId, [FromQuery] Guid? productId)
        {
            var prefix = "xpct.wal.ext";
            try
            {
                var result = _walletService.GetWalletExtract(userId, productId);

                if (result.Status == GetWalletExtractStatus.Success)
                {
                    _logger.LogInformation($"the extract was successfully consulted.");
                    return Ok(new WalletExtractResponse(result.Message, result.Extract!));
                }

                _logger.LogError($"Error searching the extract || Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }

        /// <summary>
        /// Obter Investimentos da carteira
        /// </summary>
        /// <param name="userId">código do usuario</param>
        /// <returns><see cref="WalletInvestmentsResponse"/></returns>
        [HttpGet("{userId}")]
        [Authorize(Roles = "CUSTOMER")]
        [SwaggerOperation(Summary = "Obter investimentos da carteira do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(WalletInvestmentsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult GetWalletInvestments([FromRoute] Guid userId)
        {
            var prefix = "xpct.wal.inv";
            try
            {
                var result = _walletService.GetWalletInvestments(userId);

                if (result.Status == GetWalletInvestmentsStatus.Success)
                {
                    _logger.LogInformation($"the investments was successfully consulted.");
                    return Ok(new WalletInvestmentsResponse(result.Message, result.Investment!));
                }

                _logger.LogError($"Error searching the investments || Error Message: {result.Message}.");
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
