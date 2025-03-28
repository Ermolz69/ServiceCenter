﻿using ServiceCenter.Domain.Enums;

namespace ServiceCenter.Domain.Entities
{
    /// <summary>
    /// Represents a customer order.
    /// </summary>
    /// <remarks>
    /// Contains information about the customer, their contact details, delivery address, payment method, order comments, creation date, status, and associated order items.
    /// </remarks>
    public class Order
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = null!;
        public string ContactPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;

        public PaymentMethod PaymentMethod { get; set; }

        public string? Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
