using ServiceCenter.Domain.Entities;

namespace ServiceCenter.Application.Interfaces
{
    /// <summary>
    /// Interface for managing products.
    /// </summary>
    /// <remarks>
    /// Defines methods for retrieving, creating, updating, and deleting products.
    /// </remarks>
    public interface IProductService
    {
        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A collection of all products.</returns>
        Task<IEnumerable<Product>> GetAllProductsAsync();

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product if found, otherwise null.</returns>
        Task<Product?> GetProductByIdAsync(int id);

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>The newly created product.</returns>
        Task<Product> CreateProductAsync(Product product);

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="product">The product to update.</param>
        Task UpdateProductAsync(Product product);

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        Task DeleteProductAsync(int id);
    }
}
