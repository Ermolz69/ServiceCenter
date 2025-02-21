using ServiceCenter.Domain.Entities;

namespace ServiceCenter.Application.Interfaces
{
    /// <summary>
    /// Interface for managing orders.
    /// </summary>
    /// <remarks>
    /// Defines methods for retrieving, creating, updating, and deleting orders.
    /// </remarks>
    public interface IOrderService
    {
        /// <summary>
        /// Retrieves all orders.
        /// </summary>
        /// <returns>A collection of all orders.</returns>
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        /// <summary>
        /// Retrieves an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order if found, otherwise null.</returns>
        Task<Order?> GetOrderByIdAsync(int id);

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="order">The order to create.</param>
        /// <returns>The newly created order.</returns>
        Task<Order> CreateOrderAsync(Order order);

        /// <summary>
        /// Updates an existing order.
        /// </summary>
        /// <param name="order">The order to update.</param>
        Task UpdateOrderAsync(Order order);

        /// <summary>
        /// Deletes an order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to delete.</param>
        Task DeleteOrderAsync(int id);
    }
}
