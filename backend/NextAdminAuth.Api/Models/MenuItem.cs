namespace NextAdminAuth.Api.Models;

public class MenuItem
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Path { get; set; }
    public string? Icon { get; set; } // Lucide React icon name
    public int Order { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Parent-Child Relationship
    public Guid? ParentId { get; set; }
    public MenuItem? Parent { get; set; }
    public ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();
}

