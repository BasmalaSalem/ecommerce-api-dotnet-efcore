using Microsoft.AspNetCore.Mvc;
using E_commerce.Contracts;
namespace E_commerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetAllCategories()
    {
        var categories = _categoryService.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{categoryId}")]
    public IActionResult GetCategoryById(int categoryId)
    {
        var category = _categoryService.GetCategoryById(categoryId);
        return Ok(category);
    }

    [HttpPost]
    public IActionResult AddCategory(Category category)
    {
        var addedCategory = _categoryService.AddCategory(category);
        return Ok(addedCategory);
    }

    [HttpPut]
    public IActionResult UpdateCategory(Category category)
    {
        var updatedCategory = _categoryService.UpdateCategory(category);
        return Ok(updatedCategory);
    }

    [HttpDelete("{categoryId}")]
    public IActionResult DeleteCategory(int categoryId)
    {
        var deletedCategory = _categoryService.DeleteCategory(categoryId);
        return Ok(deletedCategory);
    }
}