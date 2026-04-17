using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Modules.User.Contracts;

public interface IUserService
{
    Task<Result> AddUser(UserDto user);
    Task<Result> UpdateUser(UserDto user);
    Task<Result<UserViewModel>> GetUserDetails(Guid userId);
    Task<Result<ElderlyCareSupport.Domain.Entities.Identity.User>> GetUser(Guid userId);
    Task<Result> DeleteUser(Guid userId);
}