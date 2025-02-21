using Microsoft.AspNetCore.Mvc;

using ServiceCenter.Application.Interfaces;

using ServiceCenter.Domain.Entities;

using ServiceCenter.WebAPI.ResponseRequestModels;

namespace ServiceCenter.WebAPI.Controllers
{
    /// <summary>
    /// Controller for handling orders.
    /// </summary>
    /// <remarks>
    /// Contains endpoints for retrieving, creating, and managing orders.
    /// </remarks>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="request">Details of the order to create.</param>
        /// <returns>An action result indicating the outcome of the operation.</returns>
        /// <response code="200">The order was successfully created.</response>
        /// <response code="400">Invalid data was provided in the request.</response>
        /// <remarks>
        /// This endpoint accepts order details in the request body, validates them,
        /// and passes them to the order service for creation. If successful, the newly
        /// created order information is returned.
        /// </remarks>
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
