namespace E_commerce.Services;
using E_commerce.Contracts;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{

    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    /// </inhertdoc/>
    public Product AddProduct(Product product)
    {
        try

        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while adding a new product.", e);
        }
    }

    /// </inhertdoc/>
    public Product UpdateProduct(Product product)
    {
        try
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                throw new ApplicationException($"Product with ID {product.Id} not found.");
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.description = product.description;

            _context.SaveChanges();

            return existingProduct;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while updating the product.", e);
        }
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            var products = _context.Products
            .Include(p => p.Reviews)
            .ToList();
            return products;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving all products.", e);
        }
    }

    public Product DeleteProduct(int productId)
    {
        try
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new ApplicationException($"Product with ID {productId} not found.");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return product;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while deleting the product.", e);
        }
    }
    public Product GetProductById(int productId)
    {
        try
        {
            var product = _context.Products.FirstOrDefault(product => product.Id == productId);
            if (product == null)
            {
                throw new ApplicationException($"Product with ID {productId} not found.");
            }
            else
            {
                return product;
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving product by id.", e);
        }
    }
    public List<Product> GetProductsByCategory(int categoryId)
    {
        try
        {
            var products = _context.Products.Where(product => product.CategoryId == categoryId).ToList();
            if (products == null || products.Count == 0)
            {
                throw new ApplicationException($"No products found in category with ID {categoryId}.");
            }
            else
            {
                return products;
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving products by category.", e);
        }
    }

}