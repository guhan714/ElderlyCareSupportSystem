using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.Reponse;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Interface.Services;

public interface IAuthService
{
    Task<Result<UserViewModel>> LoginAsync(LoginViewModel user);
}