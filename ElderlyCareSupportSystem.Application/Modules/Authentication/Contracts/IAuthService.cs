using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Modules.Authentication.Contracts;

public interface IAuthService
{
    Task<Result<UserViewModel>> LoginAsync(LoginViewModel user);
}