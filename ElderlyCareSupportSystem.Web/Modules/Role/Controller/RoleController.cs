using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.Role.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElderlyCareSupportSystem.Web.Modules.Role.Controller;

[Authorize(Roles = "Admin")]
public sealed class RoleController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<IActionResult> Index()
    {
        var roles = await _roleService.GetRolesAsync();
        return View(roles);
    }
    
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] RoleViewModel role)
    {
        return Json(new {});
    }
}