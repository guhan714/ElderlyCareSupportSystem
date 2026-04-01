using ElderlyCareSupport.Domain.Entities.Identity;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Interface.Repository;

public interface IUserRepository
{
    Task<User?> AddAsync(User user);
    Task<User?> UpdateAsync(User user);
    Task<User?> DeleteAsync(Guid userId);
    Task<User?> FindAsync(Guid userId);
    Task<UserViewModel?> FindDetailsAsync(Guid userId);
    ValueTask<bool> ExistsAsync(Guid userId);
}