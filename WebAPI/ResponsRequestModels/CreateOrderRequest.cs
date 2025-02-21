using ServiceCenter.Domain.Enums;
using ServiceCenter.Application.DTOs;

namespace ServiceCenter.WebAPI.ResponseRequestModels
{
    /// <summary>
    /// Represents a request to create a new order.
    /// </summary>
    /// <remarks>
    /// Contains customer details, contact information, delivery address, payment method, comments, order status, and a list of order items.
    /// </remarks>
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; } = null!;
        public string ContactPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DeliveryAddress { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; }
        public string? Comments { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public List<OrderItemDTO> OrderItems { get; set; } = new();
    }
}
