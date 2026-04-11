using ElderlyCareSupportSystem.Application.Models.DTO;

namespace ElderlyCareSupportSystem.Application.Modules.Authentication.Contracts;

public interface IAuthenticationRepository
{
    Task<UserDto?> GetAsync(string username);
}