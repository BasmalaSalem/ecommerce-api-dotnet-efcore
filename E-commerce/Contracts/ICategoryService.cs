namespace E_commerce.Contracts;

/// <summary>
/// Defines the operations for managing categories in the e-commerce system.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Adds a new category.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <returns>The added category.</returns>
    Category AddCategory(Category category);

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="category">The category to update.</param>
    /// <returns>The updated category.</returns>
    Category UpdateCategory(Category category);

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="categoryId">The ID of the category to delete.</param>
    /// <returns>The deleted category.</returns>
    Category DeleteCategory(int categoryId);

    /// <summary>
    /// Retrieves a category by its ID.
    /// </summary>
    /// <param name="categoryId">The ID of the category to retrieve.</param>
    /// <returns>The category with the specified ID.</returns>
    Category GetCategoryById(int categoryId);

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>A list of all categories.</returns>
    List<Category> GetAllCategories();
}
