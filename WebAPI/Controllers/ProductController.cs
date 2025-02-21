using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Application.Interfaces;
using ServiceCenter.Domain.Entities;

namespace ServiceCenter.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _productService.CreateProductAsync(model);
            return Ok(new
            {
                Message = "Product successfully created",
                Data = created
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product updateModel)
        {
            if (id != updateModel.Id)
            {
                return BadRequest("ID in the path and in the model do not match.");
            }

            var existing = await _productService.GetProductByIdAsync(id);
            if (existing == null)
            {
                return NotFound("Product not found.");
            }

            existing.Name = updateModel.Name;
            existing.ShortDescription = updateModel.ShortDescription;
            existing.Description = updateModel.Description;
            existing.Price = updateModel.Price;
            existing.Category = updateModel.Category;
            existing.PhotoBase64 = updateModel.PhotoBase64;
            existing.Condition = updateModel.Condition;
            existing.Quantity = updateModel.Quantity;

            await _productService.UpdateProductAsync(existing);
            return Ok(new { Message = "Product successfully updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _productService.GetProductByIdAsync(id);
            if (existing == null)
            {
                return NotFound("Product not found.");
            }

            await _productService.DeleteProductAsync(id);
            return Ok(new { Message = "Product successfully deleted" });
        }
    }
}
