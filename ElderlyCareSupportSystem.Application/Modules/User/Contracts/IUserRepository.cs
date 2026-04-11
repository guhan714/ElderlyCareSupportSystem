using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Modules.User.Contracts;

public interface IUserRepository
{
    Task<ElderlyCareSupport.Domain.Entities.Identity.User?> AddAsync(ElderlyCareSupport.Domain.Entities.Identity.User user);
    Task<ElderlyCareSupport.Domain.Entities.Identity.User?> UpdateAsync(ElderlyCareSupport.Domain.Entities.Identity.User user);
    Task<ElderlyCareSupport.Domain.Entities.Identity.User?> DeleteAsync(Guid userId);
    Task<ElderlyCareSupport.Domain.Entities.Identity.User?> FindAsync(Guid userId);
    Task<UserViewModel?> FindDetailsAsync(Guid userId);
    ValueTask<bool> ExistsAsync(Guid userId);
}