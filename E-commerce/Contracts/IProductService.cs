namespace E_commerce.Contracts;

/// <summary>
/// Defines the operations for managing products in the e-commerce system.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Adds a new product to the system.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <returns>The added product with updated information (e.g., generated ID).</returns>
    Product AddProduct(Product product);

    /// <summary>
    /// Updates an existing product in the system.
    /// </summary>
    /// <param name="product">The product with updated details.</param>
    /// <returns>The updated product.</returns>
    Product UpdateProduct(Product product);

    /// <summary>
    /// Deletes a product from the system by its ID.
    /// </summary>
    /// <param name="productId">The ID of the product to delete.</param>
    /// <returns>The deleted product.</returns>
    Product DeleteProduct(int productId);

    /// <summary>
    /// Retrieves a product by its unique ID.
    /// </summary>
    /// <param name="productId">The ID of the product to retrieve.</param>
    /// <returns>The product with the specified ID, or null if not found.</returns>
    Product GetProductById(int productId);

    /// <summary>
    /// Retrieves all products in the system.
    /// </summary>
    /// <returns>A list of all products.</returns>
    List<Product> GetAllProducts();

    /// <summary>
    /// Retrieves all products that belong to a specific category.
    /// </summary>
    /// <param name="categoryId">The ID of the category.</param>
    /// <returns>A list of products in the specified category.</returns>
    List<Product> GetProductsByCategory(int categoryId);
}
