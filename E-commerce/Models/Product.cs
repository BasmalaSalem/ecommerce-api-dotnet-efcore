using System.Text.Json.Serialization;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string description { get; set; }
    public int CategoryId { get; set; }
    public ICollection<Review>? Reviews { get; }
}