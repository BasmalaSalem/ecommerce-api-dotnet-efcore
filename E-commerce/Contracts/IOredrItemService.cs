namespace E_commerce.Contracts;

/// <summary>
/// Defines the contract for managing order items in the e-commerce system.
/// </summary>
public interface IOrderItemService
{
    /// <summary>
    /// Adds a new order item for a specific user.
    /// </summary>
    /// <param name="orderItem">The order item to add.</param>
    /// <param name="userId">The ID of the user associated with the order item.</param>
    /// <returns>The added order item object.</returns>
    OrderItem AddOrderItem(OrderItem orderItem, int userId);

    /// <summary>
    /// Updates the details of an existing order item.
    /// </summary>
    /// <param name="orderItemId">The ID of the order item to update.</param>
    /// <param name="quantity">The new quantity of the order item.</param>
    /// <param name="productId">The new product ID associated with the order item.</param>
    /// <returns>The updated order item object.</returns>
    OrderItem UpdateOrderItem(int orderItemId, int quantity, int productId);

    /// <summary>
    /// Deletes an order item by its ID.
    /// </summary>
    /// <param name="orderItemId">The ID of the order item to delete.</param>
    /// <returns>The deleted order item object.</returns>
    OrderItem DeleteOrderItem(int orderItemId);

    /// <summary>
    /// Retrieves all order items in the system.
    /// </summary>
    /// <returns>A list of all order items.</returns>
    List<OrderItem> GetAllOrderItems();
}
