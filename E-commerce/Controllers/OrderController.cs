namespace E_commerce.Contracts;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Enums;



[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("{userId}")]
    public IActionResult CreateOrder(int userId, List<OrderItem> orderItems)
    {
        var newOrder = _orderService.CreateOrder(userId, orderItems);
        return Ok(newOrder);
    }

    [HttpDelete("{orderId}")]
    public IActionResult CancelOrder(int orderId)
    {
        var cancelledOrder = _orderService.CancelOrder(orderId);
        return Ok(cancelledOrder);
    }

    [HttpGet("{orderId}")]
    public IActionResult GetOrderById(int orderId)
    {
        var order = _orderService.GetOrderById(orderId);
        return Ok(order);
    }

    [HttpGet]
    public IActionResult GetAllOrders()
    {
        var orders = _orderService.GetAllOrders();
        return Ok(orders);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetUserOrders(int userId)
    {
        var userOrders = _orderService.GetUserOrders(userId);
        return Ok(userOrders);
    }

    [HttpPut("{orderId}/status/{newStatus}")]
    public IActionResult UpdateOrderStatus(int orderId, Status newStatus)
    {
        var updatedOrder = _orderService.UpdateOrderStatus(orderId, newStatus);
        return Ok(updatedOrder);
    }

}