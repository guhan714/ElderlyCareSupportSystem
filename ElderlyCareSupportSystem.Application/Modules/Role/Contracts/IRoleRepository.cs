using ElderlyCareSupportSystem.Application.Modules.Role.Models;

namespace ElderlyCareSupportSystem.Application.Modules.Role.Contracts;

public interface IRoleRepository
{
    Task<List<RoleViewModel>> GetAllAsync();
    Task<RoleDto?> GetByIdAsync(Guid id);
    Task<RoleDto?> GetDetailsByIdAsync(Guid id);
    Task<ElderlyCareSupport.Domain.Entities.Identity.Role?> AddAsync(
        ElderlyCareSupport.Domain.Entities.Identity.Role role);
    Task<ElderlyCareSupport.Domain.Entities.Identity.Role?> UpdateAsync(
        RoleDto role);
    Task<bool> ExistsAsync(Guid roleId);
    Task<bool> RemoveAsync(Guid roleId);
}