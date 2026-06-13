using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entity;
using WebApi.Repository;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithGenericRepoController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        public ProductWithGenericRepoController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductRequest product)
        {
            var newProduct = new Product
            {
                ProductName = product.ProductName,
                Price = product.Price
            };
            var createdProduct = await _productRepository.CreateAsync(newProduct);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.ProductId }, createdProduct);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductRequest product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            var updatedProduct = await _productRepository.UpdateAsync(existingProduct);
            //return Ok(updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteAsync(existingProduct);
            return NoContent();
        }
    }
}
