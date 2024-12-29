namespace E_commerce.Services;
using E_commerce.Contracts;
using Microsoft.EntityFrameworkCore;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;
    public CategoryService(AppDbContext context)
    {
        _context = context;
    }
    public Category AddCategory(Category category)
    {
        try
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while adding a new category.", e);
        }
    }

    public Category UpdateCategory(Category category)
    {
        try
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                throw new ApplicationException($"Category with ID {category.Id} not found.");
            }

            existingCategory.Name = category.Name;

            _context.SaveChanges();

            return existingCategory;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while updating the category.", e);
        }
    }

    public Category DeleteCategory(int categoryId)
    {
        try
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                throw new ApplicationException($"Category with ID {categoryId} not found.");
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while deleting the category.", e);
        }
    }

    public Category GetCategoryById(int categoryId)
    {
        try
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
            {
                throw new ApplicationException($"Category with ID {categoryId} not found.");
            }

            return category;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving category by ID.", e);
        }
    }

    public List<Category> GetAllCategories()
    {
        try
        {
            return _context.Categories
            .Include(c => c.Products)
            .ToList();
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving all categories.", e);
        }
    }

}