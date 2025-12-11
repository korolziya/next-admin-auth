using NextAdminAuth.Api.DTOs;

namespace NextAdminAuth.Api.Services;

public interface IAuthService
{
    Task<object> RegisterAsync(RegisterDto dto);
    Task<AuthResponseDto?> LoginAsync(LoginDto dto);
    Task<object> VerifyAsync(VerifyDto dto);
    Task<AuthResponseDto?> RefreshTokenAsync(RefreshTokenDto dto);
}

