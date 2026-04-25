using System.Security.Claims;
using ElderlyCareSupportSystem.Application.Modules.Role.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Role.Mapper;
using ElderlyCareSupportSystem.Application.Modules.Role.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElderlyCareSupportSystem.Web.Modules.Role.Controller;

[Authorize(Roles = "Admin")]
public sealed class RoleController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IValidator<RoleViewModel> _validator;
    private readonly RoleMapper _mapper;
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService, RoleMapper mapper, IValidator<RoleViewModel> validator)
    {
        _roleService = roleService;
        _mapper = mapper;
        _validator = validator;
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
    public async Task<IActionResult> Create([FromBody] RoleViewModel role)
    {
        var validation = await _validator.ValidateAsync(role);
        
        if (!validation.IsValid)
            return BadRequest(new {success = validation.IsValid,  errors = validation.Errors.Select(x => x.ErrorMessage)});
        
        var roleDto = _mapper.ToDto(role);
        var userId = GetUserId();
        var roleCreated = await _roleService.CreateRoleAsync(roleDto, userId);

        if (!roleCreated.IsSuccess)
        {
            return Json(new{success = roleCreated.IsSuccess, message = roleCreated.Message});
        }
        
        return Json(new {success = roleCreated.IsSuccess, meessage = roleCreated.Message, redirecturl = Url.Action("Index")});
    }


    [HttpGet]
    public async Task<IActionResult> Edit(Guid roleId)
    {
        if(roleId == Guid.Empty)
            throw new ArgumentException("Role Id cannot be empty");

        var role = await _roleService.GetRoleByIdAsync(roleId);
        return View(role.Data);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromBody] RoleViewModel role)
    {
        var validation = await _validator.ValidateAsync(role);
        
        if (!validation.IsValid)
            return BadRequest(new {success = validation.IsValid,  errors = validation.Errors.Select(x => x.ErrorMessage)});
        
        var roleDto = _mapper.ToDto(role);
        var userId = GetUserId();
        var roleCreated = await _roleService.EditRoleAsync(roleDto, userId);

        if (!roleCreated.IsSuccess)
        {
            return Json(new{success = roleCreated.IsSuccess, message = roleCreated.Message});
        }
        
        return Json(new {success = roleCreated.IsSuccess, message = roleCreated.Message, redirecturl = Url.Action("Index")});
    }

    [HttpGet]
    public async Task<IActionResult> Detail(Guid roleId)
    {
        if (roleId == Guid.Empty)
            throw new ArgumentException("Role Id cannot be empty");
        
        var role = await _roleService.GetDetailsAsync(roleId);
        if(!role.IsSuccess)
            return View(role.Data);
        
        return View(role.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete([FromBody]Guid roleId)
    {
        if(roleId == Guid.Empty)
            throw new ArgumentException("Role Id  cannot be empty");
        
        var result = await _roleService.DeleteRoleAsync(roleId);
        if (!result.IsSuccess)
            return Json(new{success = result.IsSuccess, message = result.Message});
        
        return Json(new {success = result.IsSuccess, message = result.Message, redirectUrl = Url.Action("Index")});
    }
    

    private Guid GetUserId()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(userId, out var result) ? result : Guid.Empty;
    }
}