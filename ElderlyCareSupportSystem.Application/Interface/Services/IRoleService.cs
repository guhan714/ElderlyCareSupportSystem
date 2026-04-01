using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Interface.Services;

public interface IRoleService
{
    Task<List<RoleViewModel>> GetRolesAsync();
}