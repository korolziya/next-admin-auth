namespace NextAdminAuth.Api.DTOs;

public class MenuItemDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Path { get; set; }
    public string? Icon { get; set; }
    public int Order { get; set; }
    public List<MenuItemDto> Children { get; set; } = new List<MenuItemDto>();
}

