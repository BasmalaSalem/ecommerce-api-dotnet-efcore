public class User {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string address { get; set; }
    public string phone { get; set; }

    public ICollection<Review>? Reviews { get; set; } = new List<Review>();
    
}