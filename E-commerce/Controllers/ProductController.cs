using E_commerce.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);

    }



    [HttpGet("{productId}")]
    public IActionResult GetProductById(int productId)
    {
        var product = _productService.GetProductById(productId);
        return Ok(product);
    }



    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        var addedProduct = _productService.AddProduct(product);
        return Ok(addedProduct);
    }


    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {

        if (id != product.Id)
        {
            return BadRequest("Product ID in the URL does not match the product ID in the body.");
        }

        var existingProduct = _productService.GetProductById(id);
        if (existingProduct == null)
        {
            return NotFound($"Product with ID {id} not found.");
        }

        _productService.UpdateProduct(product);
        return Ok(product);
    }

    [HttpDelete("{productId}")]
    public IActionResult DeleteProduct(int productId)
    {
        var product = _productService.DeleteProduct(productId);

        if (product is null)
        {
            return NotFound($"Product with id {productId} not found.");

        }
        return Ok(product);

    }

    [HttpGet("/products/{categoryId}")]
    public IActionResult GetProductsByCategory(int categoryId)
    {
        var products = _productService.GetProductsByCategory(categoryId);
        return Ok(products);
    }

}


