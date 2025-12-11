namespace NextAdminAuth.Api.Models;

public class Company
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? LogoUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Property
    public ICollection<User> Users { get; set; } = new List<User>();
}

