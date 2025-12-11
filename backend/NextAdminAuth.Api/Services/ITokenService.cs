using NextAdminAuth.Api.Models;

namespace NextAdminAuth.Api.Services;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    System.Security.Claims.ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}

