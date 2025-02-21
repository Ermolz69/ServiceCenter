using ServiceCenter.Domain.Enums;
using ServiceCenter.Application.DTOs;

namespace ServiceCenter.WebAPI.ResponseRequestModels
{
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
