using Microsoft.AspNetCore.Mvc;
using NextAdminAuth.Api.DTOs;
using NextAdminAuth.Api.Services;

namespace NextAdminAuth.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromForm] RegisterDto dto)
    {
        var result = await _authService.RegisterAsync(dto);
        // Checking if result has error property via reflection or just returning OK
        // In a real app, I'd use a Result pattern, but here I'll just return OK(result)
        // because the service returns { error = "..." } or { success = "..." } objects.
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        try
        {
            var result = await _authService.LoginAsync(dto);
            if (result == null)
            {
                return Unauthorized(new { error = "Geçersiz bilgiler!" });
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost("verify")]
    public async Task<IActionResult> Verify(VerifyDto dto)
    {
        var result = await _authService.VerifyAsync(dto);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(RefreshTokenDto dto)
    {
        var result = await _authService.RefreshTokenAsync(dto);
        if (result == null)
        {
            return BadRequest(new { error = "Invalid Token" });
        }
        return Ok(result);
    }
}

