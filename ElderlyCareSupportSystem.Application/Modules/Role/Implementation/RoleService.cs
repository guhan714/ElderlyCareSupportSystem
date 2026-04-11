using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.Role.Contracts;

namespace ElderlyCareSupportSystem.Application.Modules.Role.Implementation;

public sealed class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<List<RoleViewModel>> GetRolesAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        return roles;
    }
}