using System.Text.Json.Serialization;

public class OrderItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    [JsonIgnore]
    public decimal Price { get; set; }
    public int ProductId { get; set; }

    [JsonIgnore]
    public Product? Product { get; set; }

    public int? OrderId { get; set; }
    [JsonIgnore]
    public Order? Order { get; set; }
}