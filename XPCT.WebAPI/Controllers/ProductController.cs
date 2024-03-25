using FluentValidation;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Classe controlladora de Produto
    /// </summary>
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

        /// <summary>
        /// Instancia um <see cref="ProductController"/>
        /// </summary>
        /// <param name="logger"><see cref="ILogger{ProductController}"/></param>
        /// <param name="productService"><see cref="IProductService"/></param>
        /// <param name="addProductRequestValidator"><see cref="IValidator{T}"/> de <see cref="AddProductRequest"/></param>
        /// <param name="updateProductRequestValidator"><see cref="IValidator{T}"/> de <see cref="UpdateProductRequest"/></param>
        /// <param name="enableProductRequestValidator"><see cref="IValidator{T}"/> de <see cref="EnableProductRequest"/></param>
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

        /// <summary>
        /// Obter produtos
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> de <see cref="ProductResponse"/></returns>
        [HttpGet]
        [Authorize(Roles = "OPERATOR")]
        [SwaggerOperation(Summary = "Obtém a lista de produtos ativos ")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult GetProducts()
        {
            var prefix = "xpct.prd.gp";
            try
            {
                var result = _productService.GetProducts();

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

        /// <summary>
        /// Cadastrar Produto
        /// </summary>
        /// <param name="request"><see cref="AddProductRequest"/></param>
        /// <returns><see cref="ProductResponse"/></returns>
        [HttpPost]
        [Authorize(Roles = "OPERATOR")]
        [SwaggerOperation(Summary = "Cadastra um novo produto")]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(ProductResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult AddProduct([FromBody] AddProductRequest request)
        {
            var prefix = "xpct.prd.add";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _addProductRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = _productService.AddProduct(request.Name, request.Price, request.Active, request.DaysToDue);

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

        /// <summary>
        /// Editar Produto
        /// </summary>
        /// <param name="request"><see cref="UpdateProductRequest"/></param>
        /// <returns><see cref="ProductResponse"/></returns>
        [HttpPut]
        [Authorize(Roles = "OPERATOR")]
        [SwaggerOperation(Summary = "Edita um produto")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse), Description = "Bad Request")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult UpdateProduct([FromBody] UpdateProductRequest request)
        {
            var prefix = "xpct.prd.upd";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _updateProductRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = _productService.UpdateProduct(request.Id, request.Name, request.Price, request.DaysToDue);

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

        /// <summary>
        /// Ativa produto
        /// </summary>
        /// <param name="request"><see cref="EnableProductRequest"/></param>
        /// <returns><see cref="ProductIdentifyerResponse"/></returns>
        [HttpPost("enable")]
        [Authorize(Roles = "OPERATOR")]
        [SwaggerOperation(Summary = "Ativa um produto")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse), Description = "Bad Request")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult EnableProduct([FromBody] EnableProductRequest request)
        {
            var prefix = "xpct.prd.ena";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                var dataValidate = _enableProductRequestValidator.Validate(request);

                if (!dataValidate.IsValid)
                    return BadRequest(new BadValidationResponse(dataValidate.Errors.ToCustomValidationFailure(), prefix));

                var result = _productService.EnableProduct(request.Id);

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

        /// <summary>
        /// Inativa produto
        /// </summary>
        /// <param name="id">código do Produto</param>
        /// <returns><see cref="ProductIdentifyerResponse"/></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "OPERATOR")]
        [SwaggerOperation(Summary = "Desativa um produto")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProductIdentifyerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(BadRequestResponse), Description = "Bad Request")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Type = typeof(BadRequestResponse))]
        public IActionResult DisableProduct([FromRoute] Guid id)
        {
            var prefix = "xpct.prd.dis";
            try
            {
                _logger.LogInformation($"Attempt to validate the informed parameters.");
                if (id == Guid.Empty)
                    return BadRequest(new BadValidationResponse(new CustomValidationFailure("o Código do produto precisa ser informado","Id"), prefix));
                
                var result = _productService.DisableProduct(id);

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
