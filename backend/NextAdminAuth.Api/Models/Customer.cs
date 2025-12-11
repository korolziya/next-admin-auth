namespace NextAdminAuth.Api.Models;

public class Customer
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Her müşteri bir şirkete aittir
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}

