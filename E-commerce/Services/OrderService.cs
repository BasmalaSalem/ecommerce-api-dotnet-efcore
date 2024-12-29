namespace E_commerce.Services;

using System.Security.Cryptography;
using E_commerce.Contracts;
using E_commerce.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    public OrderService(AppDbContext context)
    {
        _context = context;
    }
    public Order CreateOrder(int userId, List<OrderItem> orderItems)
    {
        try
        {
            var userExists = _context.Users.Any(u => u.Id == userId);
            if (!userExists)
            {
                throw new ApplicationException($"User with ID {userId} not found.");
            }

            var existingPendingOrder = _context.Orders.FirstOrDefault(o => o.UserId == userId && o.Status == Status.Pending);
            if (existingPendingOrder != null)
            {
                throw new ApplicationException("User already has a pending order.");
            }

            foreach (var item in orderItems)
            {
                var productExists = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);
                if (productExists == null)
                {
                    throw new ApplicationException($"Product with ID {item.ProductId} not found.");
                }
                item.Price = productExists.Price * item.Quantity;

            }

            var newOrder = new Order
            {
                UserId = userId,
                CreatedOn = DateTime.UtcNow,
                Status = Status.Pending,
                TotalPrice = orderItems.Sum(i => i.Price),
                OrderItems = new List<OrderItem>(orderItems)
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            return newOrder;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating a new order.", e);
        }
    }

    public Order CancelOrder(int orderId)
    {
        try
        {
            Order? order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new ApplicationException($"Order with ID {orderId} not found.");
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return order;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while canceling the order.", e);
        }
    }

    public Order GetOrderById(int orderId)
    {
        try
        {
            Order? order = _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefault(oi => oi.Id == orderId);
            if (order == null)
            {
                throw new ApplicationException($"Order with ID {orderId} not found.");
            }
            return order; ;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while getting the order.", e);
        }
    }
    public List<Order> GetAllOrders()
    {
        try
        {
            var orders = _context.Orders
            .Include(o => o.OrderItems)
            .ToList();

            if (!orders.Any())
            {
                throw new ApplicationException("No orders found.");
            }
            return orders;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving all orders.", e);
        }

    }
    public List<Order> GetUserOrders(int userId)
    {
        try
        {

            var orders = _context.Orders
            .Include(o => o.OrderItems)
            .Where(o => o.UserId == userId)
            .ToList();

            if (orders == null)
            {
                throw new ApplicationException($"No orders found for user with ID {userId}.");
            }
            return orders;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving user orders.", e);
        }
    }
    public Order UpdateOrderStatus(int orderId, Status newStatus)
    {
        try
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new ApplicationException($"Order with ID {orderId} not found.");
            }
            if (!Enum.IsDefined(typeof(Status), newStatus))
            {
                throw new ApplicationException($"Invalid status: {newStatus}");
            }
            order.Status = newStatus;
            _context.SaveChanges();

            return order;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while updating the order status.", e);
        }
    }
}