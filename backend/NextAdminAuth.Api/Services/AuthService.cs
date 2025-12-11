using NextAdminAuth.Api.DTOs;
using NextAdminAuth.Api.Models;
using NextAdminAuth.Api.Repositories;
using BCrypt.Net;
using System.Security.Claims;

namespace NextAdminAuth.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IMailService _mailService;

    public AuthService(IUnitOfWork unitOfWork, ITokenService tokenService, IMailService mailService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _mailService = mailService;
    }

    public async Task<object> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _unitOfWork.Users.FindAsync(u => u.Email == dto.Email);
        if (existingUser != null)
        {
            return new { error = "Bu email adresi zaten kullanımda!" };
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        // Logo Upload Logic
        string? logoPath = null;
        if (dto.Logo != null)
        {
            // Klasör yoksa oluştur
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // Benzersiz dosya ismi oluştur
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.Logo.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Dosyayı kaydet
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Logo.CopyToAsync(fileStream);
            }

            // DB'ye kaydedilecek URL (Örn: /uploads/resim.png)
            logoPath = $"/uploads/{uniqueFileName}";
        }

        // 1. Create Company
        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = dto.CompanyName,
            LogoUrl = logoPath
        };
        
        await _unitOfWork.Companies.AddAsync(company);

        // Rolü ismine göre bul
        var adminRole = await _unitOfWork.Roles.FindAsync(r => r.Name == "Admin");
        if (adminRole == null)
        {
            return new { error = "Sistemde Admin rolü tanımlı değil!" };
        }

        // 2. Create User linked to Company
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            Password = hashedPassword,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthDate = dto.BirthDate?.ToUniversalTime(), // Postgres UTC sever
            Verified = false,
            RoleId = adminRole.Id,
            CompanyId = company.Id
        };

        var token = new Random().Next(100000, 999999).ToString();
        var expires = DateTime.UtcNow.AddMinutes(15);

        var verificationToken = new VerificationToken
        {
            Id = Guid.NewGuid(),
            Email = dto.Email,
            Token = token,
            Expires = expires
        };

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.VerificationTokens.AddAsync(verificationToken);
        
        // Transaction (UnitOfWork) saves everything at once
        await _unitOfWork.CompleteAsync();

        // Send Email
        try 
        {
            await _mailService.SendEmailAsync(dto.Email, "Doğrulama Kodu - NextAdminAuth", 
                $"<h3>Hoşgeldiniz!</h3><p>Hesabınızı doğrulamak için kodunuz:</p><h1 style='color:blue'>{token}</h1>");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Mail gönderilemedi: {ex.Message}");
        }

        return new { success = "Doğrulama kodu email adresinize gönderildi!" };
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        var user = await _unitOfWork.Users.FindAsync(u => u.Email == dto.Email, u => u.Company, u => u.Role);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
        {
            return null;
        }

        if (!user.Verified)
        {
             throw new Exception("Lütfen önce email adresinizi doğrulayın!");
        }

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        
        _unitOfWork.Users.Update(user);
        await _unitOfWork.CompleteAsync();

        // Yetkileri çek
        var permissionList = await _unitOfWork.Permissions.GetListAsync(p => p.RoleId == user.RoleId, p => p.Screen);
        
        var permissions = permissionList.Select(p => new PermissionDto(
                p.Screen?.Code ?? "", 
                p.CanRead, 
                p.CanCreate, 
                p.CanUpdate, 
                p.CanDelete
            )).ToList();

        return new AuthResponseDto(
            accessToken, 
            refreshToken,
            user.FirstName,
            user.LastName,
            user.Role?.Name ?? "",
            user.Company?.Name ?? "",
            user.Company?.LogoUrl,
            permissions
        );
    }

    public async Task<object> VerifyAsync(VerifyDto dto)
    {
        var tokenRecord = await _unitOfWork.VerificationTokens.FindAsync(t => t.Email == dto.Email && t.Token == dto.Code);
        
        if (tokenRecord == null)
        {
            return new { error = "Kod bulunamadı veya hatalı!" };
        }

        if (tokenRecord.Expires < DateTime.UtcNow)
        {
            return new { error = "Kodun süresi dolmuş!" };
        }

        var user = await _unitOfWork.Users.FindAsync(u => u.Email == dto.Email);
        if (user == null)
        {
            return new { error = "Kullanıcı bulunamadı!" };
        }

        user.Verified = true;
        _unitOfWork.Users.Update(user);
        _unitOfWork.VerificationTokens.Remove(tokenRecord);
        await _unitOfWork.CompleteAsync();

        return new { success = "Email başarıyla doğrulandı!" };
    }

    public async Task<AuthResponseDto?> RefreshTokenAsync(RefreshTokenDto dto)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(dto.AccessToken);
        if (principal == null) return null;

        var email = principal.FindFirstValue(ClaimTypes.Email);
        if (email == null) return null;

        var user = await _unitOfWork.Users.FindAsync(u => u.Email == email);
        if (user == null || user.RefreshToken != dto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            return null;
        }

        var newAccessToken = _tokenService.GenerateAccessToken(user);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        _unitOfWork.Users.Update(user);
        await _unitOfWork.CompleteAsync();

        // Yetkileri çek
        var permissionList = await _unitOfWork.Permissions.GetListAsync(p => p.RoleId == user.RoleId, p => p.Screen);
        
        var permissions = permissionList.Select(p => new PermissionDto(
                p.Screen?.Code ?? "", 
                p.CanRead, 
                p.CanCreate, 
                p.CanUpdate, 
                p.CanDelete
            )).ToList();

        return new AuthResponseDto(
            newAccessToken, 
            newRefreshToken,
            user.FirstName,
            user.LastName,
            user.Role?.Name ?? "",
            user.Company?.Name ?? "",
            user.Company?.LogoUrl,
            permissions
        );
    }
}
