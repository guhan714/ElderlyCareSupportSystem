using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupport.Domain.Entities.Identity;
using ElderlyCareSupportSystem.Application.Models.DTO;

namespace ElderlyCareSupportSystem.Application.Interface.Repository;

public interface IAuthenticationRepository
{
    Task<UserDto?> GetAsync(string username);
}