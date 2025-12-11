namespace NextAdminAuth.Api.Models;

public class VerificationToken
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }
    public DateTime Expires { get; set; }
}

