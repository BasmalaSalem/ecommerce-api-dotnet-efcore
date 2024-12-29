using System.Text.Json.Serialization;
using E_commerce.Enums;

public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedOn { get; set; }

    public int UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; set; } = Status.Pending;
    public List<OrderItem> OrderItems { get; set; }
}

