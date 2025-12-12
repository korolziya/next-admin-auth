namespace NextAdminAuth.Api.Models;

public class Company : BaseEntity
{
    public required string Name { get; set; }
    public string? LogoUrl { get; set; }

    // Navigation Property
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
