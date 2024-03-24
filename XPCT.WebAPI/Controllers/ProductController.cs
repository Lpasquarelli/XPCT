using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using XPCT.Application.DTO.Response;
using XPCT.Application.Interfaces;
using XPCT.Application.Results.Products;
using XPCT.WebAPI.Models.Request.Product;
using XPCT.WebAPI.Models.Response;
using XPCT.WebAPI.Validators;

namespace XPCT.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IValidator<AddProductRequest> _addProductRequestValidator;
        private readonly IValidator<UpdateProductRequest> _updateProductRequestValidator;
        private readonly IValidator<EnableProductRequest> _enableProductRequestValidator;
        public ProductController(ILogger<ProductController> logger,
            IProductService productService,
            IValidator<AddProductRequest> addProductRequestValidator,
            IValidator<UpdateProductRequest> updateProductRequestValidator,
            IValidator<EnableProductRequest> enableProductRequestValidator
            )
        {
            _logger = logger;
            _productService = productService;
            _addProductRequestValidator = addProductRequestValidator;
            _updateProductRequestValidator = updateProductRequestValidator;
            _enableProductRequestValidator = enableProductRequestValidator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de produtos ativos ")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> GetProducts()
        {
            var prefix = "xpct.prd.gp";
            try
            {
                var result = await _productService.GetProductsAsync();

                if(result.Status == GetProductsStatus.Success)
                {
                    _logger.LogInformation($"Product search carried out successfully.");
                    return Ok(result.Products);
                }

                _logger.LogError($"Error searching products || Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo produto")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ProductResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            var prefix = "xpct.prd.add";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _addProductRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = await _productService.AddProductAsync(request.Name, request.Price, request.Active, request.DaysToDue);

                if (result.Status == AddProductStatus.Success)
                {
                    _logger.LogInformation($"Product registered successfully.");
                    return Created("Product registered successfully", result.Product);
                }

                _logger.LogError($"Error registering the product || Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Edita um produto")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse), Description = "Bad Request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            var prefix = "xpct.prd.upd";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _updateProductRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = await _productService.UpdateProductAsync(request.Id, request.Name, request.Price, request.DaysToDue);

                if (result.Status == UpdateProductStatus.Success)
                {
                    _logger.LogInformation($"Product has been updated successfully.");
                    return Ok(result.Product);
                }

                _logger.LogError($"Error updating the product || Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }

        [HttpPost("enable")]
        [SwaggerOperation(Summary = "Ativa um produto")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse), Description = "Bad Request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> EnableProduct([FromBody] EnableProductRequest request)
        {
            var prefix = "xpct.prd.ena";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _enableProductRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = await _productService.EnableProductAsync(request.Id);

                if (result.Status == EnableProductStatus.Success ||
                    result.Status == EnableProductStatus.ProductAlreadyEnabled)
                {
                    _logger.LogInformation(result.Message);
                    return Ok(new ProductIdentifyerResponse(result.Product!.Id, result.Message));
                }

                _logger.LogError($"Error enabling the product || Error Message: {result.Message}.");
                return BadRequest(new BadRequestResponse(result.Message, $"{prefix}.400"));

            }
            catch (Exception ex)
            {
                _logger.LogCritical($"CRITICAL ERROR AT: {ex.StackTrace} || Error Message: {ex.Message}.");
                return BadRequest(new BadRequestResponse(ex, $"{prefix}.500"));
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Desativa um produto")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse), Description = "Bad Request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public async Task<IActionResult> DisableProduct([FromRoute] Guid id)
        {
            var prefix = "xpct.prd.dis";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                if (id == Guid.Empty)
                    return BadRequest(new BadValidationResponse(new CustomValidationFailure("o Código do produto precisa ser informado","Id"), prefix));
                
                var result = await _productService.DisableProductAsync(id);

                if (result.Status == DisableProductStatus.Success ||
                    result.Status == DisableProductStatus.ProductAlreadyDisabled)
                {
                    _logger.LogInformation(result.Message);
                    return Ok(new ProductIdentifyerResponse(result.Product!.Id, result.Message));
                }

                _logger.LogError($"Error disabling the product || Error Message: {result.Message}.");
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
