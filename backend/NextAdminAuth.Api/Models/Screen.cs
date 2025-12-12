namespace NextAdminAuth.Api.Models;

public class Screen : BaseEntity
{
    public required string Name { get; set; } // Customers, Users, Settings
    public required string Code { get; set; } // unique code: PAGE_CUSTOMERS
}
