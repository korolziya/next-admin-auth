using Microsoft.AspNetCore.Http;

namespace NextAdminAuth.Api.DTOs;

public class RegisterDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public required string CompanyName { get; set; }
    public IFormFile? Logo { get; set; } // Dosya buraya gelecek
}

public record LoginDto(string Email, string Password);
public record VerifyDto(string Email, string Code);
public record PermissionDto(string ScreenCode, bool CanRead, bool CanCreate, bool CanUpdate, bool CanDelete);

public record AuthResponseDto(
    string AccessToken, 
    string RefreshToken,
    string FirstName,
    string LastName,
    string Role,
    string CompanyName,
    string? CompanyLogo,
    List<PermissionDto> Permissions
);
public record RefreshTokenDto(string AccessToken, string RefreshToken);
