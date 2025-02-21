using Microsoft.AspNetCore.Mvc;
using ServiceCenter.Application.Interfaces;
using ServiceCenter.Domain.Entities;
using ServiceCenter.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using ServiceCenter.WebAPI.ResponseRequestModels;

namespace ServiceCenter.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = new Order
            {
                CustomerName = request.CustomerName,
                ContactPhone = request.ContactPhone,
                Email = request.Email,
                DeliveryAddress = request.DeliveryAddress,
                PaymentMethod = request.PaymentMethod,
                Comments = request.Comments,
                Status = request.Status,
                OrderItems = request.OrderItems.Select(oi => new OrderItem
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }).ToList()
            };

            var createdOrder = await _orderService.CreateOrderAsync(order);
            return Ok(new
            {
                Message = "Order successfully created",
                Data = createdOrder
            });
        }
    }
}
