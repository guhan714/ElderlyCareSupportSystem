using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Modules.Role.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Role.Mapper;
using ElderlyCareSupportSystem.Application.Modules.Role.Models;

namespace ElderlyCareSupportSystem.Application.Modules.Role.Implementation;

public sealed class RoleService : IRoleService
{
    private readonly RoleMapper _mapper;
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository, RoleMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<List<RoleViewModel>> GetRolesAsync()
    {
        var roles = await _roleRepository.GetAllAsync();
        return roles;
    }

    public async Task<Result<RoleViewModel>> GetRoleByIdAsync(Guid roleId)
    {
        var roleResult = await _roleRepository.GetByIdAsync(roleId);

        if (roleResult is null)
            return Result<RoleViewModel>.Fail("Role not found");
        
        var roleViewResult = _mapper.ToViewModel(roleResult);
        return Result<RoleViewModel>.Success(roleViewResult);
    }

    public async Task<Result> CreateRoleAsync(RoleDto role, Guid userId)
    {
        var roleDomain = _mapper.ToUser(role);
        roleDomain.Id = Guid.NewGuid();
        roleDomain.CreatedById = userId;
        roleDomain.CreatedBy = null;
        roleDomain.CreatedOn = DateTime.UtcNow;
        roleDomain.ModifiedById = userId;
        roleDomain.ModifiedBy = null;
        roleDomain.ModifiedOn = DateTime.UtcNow;
        
        var roleCreationResult = await _roleRepository.AddAsync(roleDomain);

        if (roleCreationResult is null)
            return Result.Fail("Error creating role");
        
        return Result.Success("Role has been created");
    }

    public async Task<Result> EditRoleAsync(RoleDto role, Guid userId)
    {
        var isValidRole = await _roleRepository.ExistsAsync(role.Id);
        if(!isValidRole)
            return Result.Fail("Role not found");
        
        var roleCreationResult = await _roleRepository.UpdateAsync(role);

        if (roleCreationResult is null)
            return Result.Fail("Error creating role");
        
        return Result.Success("Role has been updated");
    }

    public async Task<Result> DeleteRoleAsync(Guid roleId)
    {
        var isValidRole = await _roleRepository.ExistsAsync(roleId);

        if (!isValidRole)
            return Result.Fail("Role not found");
        
        var deleteResult = await _roleRepository.RemoveAsync(roleId);
        
        return Result.Success("Role has been removed");
    }
}