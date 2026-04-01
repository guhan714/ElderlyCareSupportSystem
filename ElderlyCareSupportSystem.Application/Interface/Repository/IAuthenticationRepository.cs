using ElderlyCareSupportSystem.Application.Models.DTO;

namespace ElderlyCareSupportSystem.Application.Interface.Repository;

public interface IAuthenticationRepository
{
    Task<UserDto?> GetAsync(string username);
}