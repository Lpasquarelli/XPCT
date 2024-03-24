using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.DTO.Response;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.Products;
using XPCT.Application.Results.Wallet;
using XPCT.WebAPI.Models.Request.Wallet;
using XPCT.WebAPI.Models.Response;

namespace XPCT.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WalletController : Controller
    {
        private readonly ILogger<WalletController> _logger;
        private readonly IWalletService _walletService;
        public WalletController(ILogger<WalletController> logger,
            IWalletService walletService)
        {
            _logger = logger;
            _walletService = walletService;
        }

        [HttpPost("buy")]
        [SwaggerOperation(Summary = "Compra de Investimento")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(WalletIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> BuyInvestments([FromBody] BuyInvestmentsRequest request)
        {
            var prefix = "xpct.wal.buy";
            try
            {
                var result = await _walletService.BuyInvestmentAsync(request.UserId, request.Quantity, request.ProductId);

                if (result.Status == BuyInvestmentStatus.Success)
                {
                    _logger.LogInformation($"Product purchased successfully.");
                    return Ok(new WalletIdentifyerResponse(result.Wallet.Id, result.Message));
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

        [HttpPost("sell")]
        [SwaggerOperation(Summary = "Venda de Investimento")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(WalletIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> SellInvestments([FromBody] SellInvestmentsRequest request)
        {
            var prefix = "xpct.wal.sell";
            try
            {
                var result = await _walletService.SellInvestmentAsync(request.UserId, request.Quantity, request.ProductId);

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

        [HttpGet("extract/{userId}")]
        [SwaggerOperation(Summary = "Obter extrato da carteira do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(WalletExtractResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> GetWalletExtract([FromRoute] Guid userId, [FromQuery] Guid? productId)
        {
            var prefix = "xpct.wal.ext";
            try
            {
                var result = await _walletService.GetWalletExtractAsync(userId, productId);

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

        [HttpGet("{userId}")]
        [SwaggerOperation(Summary = "Obter investimentos da carteira do usuário")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(WalletInvestmentsResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> GetWalletInvestments([FromRoute] Guid userId)
        {
            var prefix = "xpct.wal.inv";
            try
            {
                var result = await _walletService.GetWalletInvestmentsAsync(userId);

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
