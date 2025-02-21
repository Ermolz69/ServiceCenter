using System.Text.Json.Serialization;

namespace ServiceCenter.Domain.Entities
{
    /// <summary>
    /// Represents an item within an order.
    /// </summary>
    /// <remarks>
    /// Contains details about the product, its quantity, price, and references to the associated order.
    /// </remarks>
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
