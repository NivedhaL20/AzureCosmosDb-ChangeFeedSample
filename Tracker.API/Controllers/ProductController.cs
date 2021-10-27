using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Tracker.Models.ViewModel;
using Tracker.Services.Interface;

namespace Tracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _productService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var result = await _productService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        [HttpPost("addOrUpdate")]
        public async Task<IActionResult> AddOrUpdateAsync([FromBody] ProductViewModel product)
        {
            try
            {
                var result = await _productService.AddOrUpdateAsync(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }        
    }
}
