using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Modules.Role.Contracts;

public interface IRoleService
{
    Task<List<RoleViewModel>> GetRolesAsync();
}