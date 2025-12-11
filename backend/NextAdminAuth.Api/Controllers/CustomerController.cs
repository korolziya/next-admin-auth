using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextAdminAuth.Api.Models;
using NextAdminAuth.Api.Repositories;

namespace NextAdminAuth.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roleIdStr = User.FindFirstValue("roleId");
        if (string.IsNullOrEmpty(roleIdStr)) return Unauthorized();

        var roleId = Guid.Parse(roleIdStr);
        var companyId = User.FindFirstValue("companyId");

        // İzin Kontrolü
        // Screen kodunu sabit veriyoruz "PAGE_CUSTOMERS"
        var permission = await _unitOfWork.Permissions.FindAsync(p => p.RoleId == roleId && p.Screen.Code == "PAGE_CUSTOMERS", p => p.Screen);
        
        if (permission == null || !permission.CanRead)
        {
            return Forbid(); // 403 Forbidden
        }

        IEnumerable<Customer> customers;

        // SuperAdmin kontrolü: İstersek Role adına göre, istersek Permission tablosundaki bir flag'e göre yapabiliriz.
        // Ama RBAC mantığında SuperAdmin rolünün "CanRead" yetkisi zaten true olmalı ve tüm veriyi görme yetkisi ayrıca tanımlanmalı.
        // Şimdilik basitleştirmek için: RoleName "SuperAdmin" ise hepsini görsün.
        var roleName = User.FindFirstValue(ClaimTypes.Role);

        if (roleName == "SuperAdmin")
        {
            customers = await _unitOfWork.Customers.GetAllAsync();
        }
        else
        {
            if (string.IsNullOrEmpty(companyId)) return Unauthorized();
            customers = (await _unitOfWork.Customers.GetAllAsync())
                        .Where(c => c.CompanyId.ToString() == companyId);
        }

        return Ok(customers);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        var roleIdStr = User.FindFirstValue("roleId");
        if (string.IsNullOrEmpty(roleIdStr)) return Unauthorized();

        var roleId = Guid.Parse(roleIdStr);
        var companyId = User.FindFirstValue("companyId");
        var roleName = User.FindFirstValue(ClaimTypes.Role);

        // İzin Kontrolü
        var permission = await _unitOfWork.Permissions.FindAsync(p => p.RoleId == roleId && p.Screen.Code == "PAGE_CUSTOMERS", p => p.Screen);
        
        if (permission == null || !permission.CanCreate)
        {
            return Forbid();
        }

        if (roleName != "SuperAdmin" && string.IsNullOrEmpty(companyId))
        {
            return Unauthorized();
        }

        if (roleName != "SuperAdmin")
        {
            customer.CompanyId = Guid.Parse(companyId!);
        }

        customer.Id = Guid.NewGuid();
        customer.CreatedAt = DateTime.UtcNow;
        customer.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Customers.AddAsync(customer);
        await _unitOfWork.CompleteAsync();

        return Ok(customer);
    }
}

