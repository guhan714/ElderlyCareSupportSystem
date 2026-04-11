using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Modules.Role.Contracts;

public interface IRoleRepository
{
    Task<List<RoleViewModel>> GetAllAsync();
}