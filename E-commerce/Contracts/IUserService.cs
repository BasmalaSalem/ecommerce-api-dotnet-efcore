namespace E_commerce.Contracts;

/// <summary>
/// Defines the contract for managing users in the e-commerce system.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Adds a new user to the system.
    /// </summary>
    /// <param name="user">The user object containing the details of the new user.</param>
    /// <returns>The added user object.</returns>
    User AddUser(User user);

    /// <summary>
    /// Updates an existing user's details.
    /// </summary>
    /// <param name="user">The user object containing the updated information.</param>
    /// <returns>The updated user object.</returns>
    User UpdateUser(User user);

    /// <summary>
    /// Deletes a user by their ID.
    /// </summary>
    /// <param name="userId">The ID of the user to delete.</param>
    /// <returns>The deleted user object.</returns>
    User DeleteUser(int userId);

    /// <summary>
    /// Retrieves all users in the system.
    /// </summary>
    /// <returns>A list of all user objects.</returns>
    List<User> GetAllUsers();
}
