
namespace E_commerce.Controllers;
using E_commerce.Contracts;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;
    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }
    [HttpGet]
    public IActionResult GetAllOrderItems()
    {
        var orderItems = _orderItemService.GetAllOrderItems();
        return Ok(orderItems);
    }

    [HttpPost]
    public IActionResult AddOrderItem(OrderItem orderItem, int userId)
    {
        var addedOrderItem = _orderItemService.AddOrderItem(orderItem, userId);
        return Ok(addedOrderItem);
    }

    [HttpPut("{orderItemId}")]
    public IActionResult UpdateOrderItem(int orderItemId, int quantity, int productId)
    {
        var updatedOrderItem = _orderItemService.UpdateOrderItem(orderItemId, quantity, productId);
        return Ok(updatedOrderItem);
    }

    [HttpDelete("{orderItemId}")]
    public IActionResult DeleteOrderItem(int orderItemId)
    {
        var deletedOrderItem = _orderItemService.DeleteOrderItem(orderItemId);
        return Ok(deletedOrderItem);
    }

}