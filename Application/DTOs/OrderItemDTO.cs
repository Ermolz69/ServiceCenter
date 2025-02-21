namespace ServiceCenter.Application.DTOs
{
    /// <summary>
    /// Represents an item in an order.
    /// </summary>
    /// <remarks>
    /// Contains the product ID, quantity, and price of the item.
    /// </remarks>
    public class OrderItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
