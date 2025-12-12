using System.ComponentModel.DataAnnotations;

namespace NextAdminAuth.Api.Models;

public abstract class BaseEntity : ISoftDelete
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Soft Delete Implementation
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}

