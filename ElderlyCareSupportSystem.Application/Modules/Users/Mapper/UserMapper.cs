using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Modules.Users.Mapper;

public static class UserMapper
{

    public static ElderlyCareSupport.Domain.Entities.Identity.User ToUser(UserDto userDto)
    {
        return new  ElderlyCareSupport.Domain.Entities.Identity.User()
        {
            Id = userDto.UserId,
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = DateTime.UtcNow,
            CreatedUserId = userDto.CreatedByUserId,
            ModifiedUserId = userDto.ModifiedByUserId,
            Email = userDto.Email,
            Username = userDto.UserName,
            PasswordHash = userDto.PasswordHash,
        };
    }
}