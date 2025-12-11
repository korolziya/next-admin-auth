namespace NextAdminAuth.Api.Models;

public class Role
{
    public Guid Id { get; set; }
    public required string Name { get; set; } // Admin, User, SuperAdmin
    public string? Description { get; set; }
    
    // Navigation
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}

