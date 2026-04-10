using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Interface.Services;

public interface IAuthService
{
    Task<Result<UserViewModel>> LoginAsync(LoginViewModel user);
}