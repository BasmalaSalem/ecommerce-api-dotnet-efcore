namespace E_commerce.Contracts;
using E_commerce.Enums;

/// <summary>
/// Defines the contract for order-related operations in the e-commerce system.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Creates a new order for the specified user with the given order items.
    /// </summary>
    /// <param name="userId">The ID of the user placing the order.</param>
    /// <param name="orderItems">A list of items to be included in the order.</param>
    /// <returns>The created order object.</returns>
    Order CreateOrder(int userId, List<OrderItem> orderItems);

    /// <summary>
    /// Retrieves the details of a specific order by its ID.
    /// </summary>
    /// <param name="orderId">The ID of the order to retrieve.</param>
    /// <returns>The order object corresponding to the given ID.</returns>
    Order GetOrderById(int orderId);

    /// <summary>
    /// Retrieves all orders in the system.
    /// </summary>
    /// <returns>A list of all orders.</returns>
    List<Order> GetAllOrders();

    /// <summary>
    /// Cancels an order by its ID and updates its status to canceled.
    /// </summary>
    /// <param name="orderId">The ID of the order to cancel.</param>
    /// <returns>The updated order object with the status set to canceled.</returns>
    Order CancelOrder(int orderId);

    /// <summary>
    /// Retrieves all orders placed by a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user whose orders are to be retrieved.</param>
    /// <returns>A list of orders placed by the specified user.</returns>
    List<Order> GetUserOrders(int userId);

    /// <summary>
    /// Updates the status of an existing order.
    /// </summary>
    /// <param name="orderId">The ID of the order to update.</param>
    /// <param name="newStatus">The new status to assign to the order.</param>
    /// <returns>The updated order object with the new status.</returns>
    Order UpdateOrderStatus(int orderId, Status newStatus);
}
