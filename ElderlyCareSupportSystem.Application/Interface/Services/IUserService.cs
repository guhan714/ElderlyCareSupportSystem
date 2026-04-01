using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupport.Domain.Entities.Identity;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.Reponse;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Interface.Services;

public interface IUserService
{
    Task<Result> AddUser(UserDto user);
    Task<Result> UpdateUser(UserDto user);
    Task<Result<UserViewModel>> GetUserDetails(Guid userId);
    Task<Result<User>> GetUser(Guid userId);
    Task<Result> DeleteUser(Guid userId);
}