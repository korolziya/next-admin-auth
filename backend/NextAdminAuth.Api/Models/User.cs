namespace NextAdminAuth.Api.Models;

public class User
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool Verified { get; set; }
    
    // Foreign Key for Role Table
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Foreign Key
    public Guid CompanyId { get; set; }
    // Navigation Property
    public Company? Company { get; set; }
}
