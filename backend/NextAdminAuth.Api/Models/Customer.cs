using System.ComponentModel.DataAnnotations;

namespace NextAdminAuth.Api.Models;

public class Customer : BaseEntity
{
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string Tckn { get; set; } = string.Empty;
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }

    // Her müşteri bir şirkete aittir
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}
