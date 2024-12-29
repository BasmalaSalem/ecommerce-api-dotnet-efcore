namespace E_commerce.Services;
using E_commerce.Contracts;
using E_commerce.Enums;
using Microsoft.EntityFrameworkCore;


public class OrderItemService : IOrderItemService
{
    private readonly AppDbContext _context;
    public OrderItemService(AppDbContext context)
    {
        _context = context;
    }
    public OrderItem AddOrderItem(OrderItem orderItem, int userId)
    {
        try
        {
            Order? activeOrder = _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefault(o => o.UserId == userId && o.Status == Status.Pending);

            if (activeOrder == null)
            {
                activeOrder = new Order
                {
                    UserId = userId,
                    CreatedOn = DateTime.UtcNow,
                    TotalPrice = 0,
                    OrderItems = new List<OrderItem>()
                };

                _context.Orders.Add(activeOrder);
                _context.SaveChanges();
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == orderItem.ProductId);
            if (product == null)
            {
                throw new ApplicationException($"Product with ID {orderItem.ProductId} not found.");
            }

            orderItem.Price = orderItem.Quantity * product.Price;
            orderItem.OrderId = activeOrder.Id;

            activeOrder.OrderItems.Add(orderItem);
            activeOrder.TotalPrice += orderItem.Price;

            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();

            return orderItem;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while adding a new order item.", e);
        }
    }

    public OrderItem UpdateOrderItem(int orderItemId, int quantity, int productId)
    {
        try
        {
            OrderItem? existingOrderItem = _context.OrderItems
                .Include(oi => oi.Order)
                .FirstOrDefault(oi => oi.Id == orderItemId);

            if (existingOrderItem == null)
            {
                throw new ApplicationException($"Order item with ID {orderItemId} not found.");
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new ApplicationException($"Product with ID {productId} not found.");
            }
            existingOrderItem.Quantity = quantity;
            existingOrderItem.ProductId = productId;
            existingOrderItem.Price = quantity * product.Price;

            if (existingOrderItem.Order != null)
            {
                existingOrderItem.Order.TotalPrice += existingOrderItem.Price;
            }
            _context.SaveChanges();

            return existingOrderItem;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while updating the order item.", e);
        }
    }

    public OrderItem DeleteOrderItem(int orderItemId)
    {
        try
        {
            var orderItem = _context.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
            if (orderItem == null)
            {
                throw new ApplicationException($"Order item with ID {orderItemId} not found.");
            }

            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();

            return orderItem;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while deleting the order item.", e);
        }
    }

    public List<OrderItem> GetAllOrderItems()
    {
        return _context.OrderItems.ToList();
    }
}