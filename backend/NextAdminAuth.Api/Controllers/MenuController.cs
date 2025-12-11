using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextAdminAuth.Api.DTOs;
using NextAdminAuth.Api.Models;
using NextAdminAuth.Api.Repositories;

namespace NextAdminAuth.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public MenuController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetMenu()
    {
        var allMenuItems = (await _unitOfWork.MenuItems.GetAllAsync())
                           .Where(m => m.IsActive)
                           .OrderBy(m => m.Order)
                           .ToList();

        // Build Hierarchy
        var rootItems = allMenuItems.Where(m => m.ParentId == null).ToList();
        var result = rootItems.Select(m => MapToDto(m, allMenuItems)).ToList();

        return Ok(result);
    }

    private MenuItemDto MapToDto(MenuItem item, List<MenuItem> allItems)
    {
        var dto = new MenuItemDto
        {
            Id = item.Id,
            Title = item.Title,
            Path = item.Path,
            Icon = item.Icon,
            Order = item.Order,
            Children = allItems
                .Where(c => c.ParentId == item.Id)
                .OrderBy(c => c.Order)
                .Select(c => MapToDto(c, allItems))
                .ToList()
        };
        return dto;
    }
}

