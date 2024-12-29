public class Review
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    // Foreign Key Fields
    public int ProductId { get; set; }
    public int UserId { get; set; }
}