namespace NextAdminAuth.Api.Models;

public class Permission
{
    public Guid Id { get; set; }
    
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public Guid ScreenId { get; set; }
    public Screen Screen { get; set; } = null!;

    // Yetkiler (Bitwise da olabilir ama basit bool daha anlaşılır)
    public bool CanRead { get; set; }
    public bool CanCreate { get; set; }
    public bool CanUpdate { get; set; }
    public bool CanDelete { get; set; }
}

