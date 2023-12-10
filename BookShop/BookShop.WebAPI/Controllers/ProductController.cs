using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Configuration;
using BookShop.BL.Products;
using BookShop.BL.Products.Entities;
using BookShop.WebAPI.Controllers.Entiteis;
using BookShop.WebAPI.Controllers.Entities;

namespace BookShop.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductsProvider _productsProvider;
        private readonly IProductsManager _productsManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductController(IProductsProvider productsProvider, IProductsManager productsManager, IMapper mapper, ILogger logger)
        {
            _productsManager = productsManager;
            _productsProvider = productsProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet] //products/
        public IActionResult GetAllProducts()
        {
            var products = _productsProvider.GetProducts();
            return Ok(new ProductsListResponce()
            {
                Products = products.ToList()
            });
        }

        [HttpGet]
        [Route("filter")] //products/filter?filter.Price = 500&filter.Status = 1&filter.PublishingHouseId = 1&filter.LanguageId = 1&filter.ProductType = 1 
        public IActionResult GetFilteredProducts([FromQuery] ProductsFilter filter)
        {
            var products = _productsProvider.GetProducts(_mapper.Map<ProductModelFilter>(filter));
            return Ok(new ProductsListResponce()
            {
                Products = products.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")] //products/{id}
        public IActionResult GetProductInfo([FromRoute] Guid id)
        {
            try
            {
                var product = _productsProvider.GetProductInfo(id);
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductRequest request)
        {
            try
            {
                var product = _productsManager.CreateProduct(_mapper.Map<CreateProductModel>(request));
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProductInfo([FromRoute] Guid id, UpdateProductRequest request)
        {
            try
            {
                var product = _productsManager.UpdateProduct(id, _mapper.Map<UpdateProductModel>(request));
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                _productsManager.DeleteProduct(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);

            }
        }
    }
}
