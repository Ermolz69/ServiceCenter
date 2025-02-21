using Domain.Enums;
using ServiceCenter.Domain.Enums;

namespace ServiceCenter.Domain.Entities
{
    /// <summary>
    /// Represents a product entity.
    /// </summary>
    /// <remarks>
    /// Contains the product’s basic details such as name, description, category, price, condition, photo, and quantity.
    /// </remarks>
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public string PhotoBase64 { get; set; } = null!;

        public ProductCondition Condition { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
