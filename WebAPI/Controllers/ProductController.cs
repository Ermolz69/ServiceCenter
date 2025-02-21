using Microsoft.AspNetCore.Mvc;

using ServiceCenter.Application.Interfaces;

using ServiceCenter.Domain.Entities;

namespace ServiceCenter.WebAPI.Controllers
{
    /// <summary>
    /// Product management controller.
    /// </summary>
    /// <remarks>
    /// Provides endpoints for retrieving, creating, updating, and deleting products.
    /// </remarks>
    /// <response code="200">Indicates a successful operation.</response>
    /// <response code="400">Indicates a bad request due to invalid input.</response>
    /// <response code="404">Indicates that the specified resource was not found.</response>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A collection of all products.</returns>
        /// <response code="200">A list of products was successfully retrieved.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Retrieves a product by ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product details if found; otherwise, a 404 response.</returns>
        /// <response code="200">The product was successfully retrieved.</response>
        /// <response code="404">No product was found with the specified ID.</response>
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

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="model">The product model to create.</param>
        /// <returns>The created product's details.</returns>
        /// <response code="200">The product was successfully created.</response>
        /// <response code="400">The provided model is invalid.</response>
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

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="updateModel">The updated product model.</param>
        /// <returns>A success message if the update is successful.</returns>
        /// <response code="200">The product was successfully updated.</response>
        /// <response code="400">The ID in the path does not match the model ID or the model is invalid.</response>
        /// <response code="404">The specified product was not found.</response>
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

        /// <summary>
        /// Deletes a product by ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>A success message if the product is successfully deleted.</returns>
        /// <response code="200">The product was successfully deleted.</response>
        /// <response code="404">The specified product was not found.</response>
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
