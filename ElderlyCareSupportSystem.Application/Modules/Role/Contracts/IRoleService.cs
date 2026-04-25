using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Modules.Role.Models;

namespace ElderlyCareSupportSystem.Application.Modules.Role.Contracts;

public interface IRoleService
{
    Task<List<RoleViewModel>> GetRolesAsync();
    Task<Result<RoleViewModel>> GetRoleByIdAsync(Guid roleId);
    Task<Result<RoleViewModel>> GetDetailsAsync(Guid roleId);
    Task<Result> CreateRoleAsync(RoleDto role, Guid userId);
    Task<Result> EditRoleAsync(RoleDto role, Guid userId);
    Task<Result> DeleteRoleAsync(Guid roleId);
}