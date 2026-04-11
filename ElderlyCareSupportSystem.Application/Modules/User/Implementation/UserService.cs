using ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.Security.Contracts;
using ElderlyCareSupportSystem.Application.Modules.User.Contracts;

namespace ElderlyCareSupportSystem.Application.Modules.User.Implementation;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IHashingService _hashingService;
    private readonly DomainMapper _domainMapper;

    public UserService(IUserRepository userRepository, DomainMapper domainMapper, IHashingService hashingService)
    {
        _userRepository = userRepository;
        _domainMapper = domainMapper;
        _hashingService = hashingService;
    }

    public async Task<Result> AddUser(UserDto user)
    {
        var userEntity = new ElderlyCareSupport.Domain.Entities.Identity.User
        {
            Id = user.UserId,
            CreatedOn = DateTime.UtcNow,
            ModifiedOn = DateTime.UtcNow,
            CreatedUserId = user.CreatedByUserId,
            ModifiedUserId = user.ModifiedByUserId,
            Email = user.Email,
            Username = user.UserName,
            PasswordHash = _hashingService.HashPassword(user.PasswordHash),
        };

        var userCreationResult = await _userRepository.AddAsync(userEntity);

        if (userCreationResult == null)
            return Result.Fail("Can't create user");

        return Result.Success($"User {userEntity.Username} has been created");
    }

    public async Task<Result> UpdateUser(UserDto user)
    {
        var validUser = await _userRepository.ExistsAsync(user.UserId);
        if(!validUser)
            return Result.Fail("User not found");

        var userEntity = _domainMapper.ToUser(user);
        userEntity.ModifiedOn = DateTime.UtcNow;
        userEntity.ModifiedUserId = userEntity.Id;
        var userUpdateResult = await _userRepository.UpdateAsync(userEntity);
        
        if (userUpdateResult == null)
            return Result.Fail("Can't update user");
        return Result.Success($"User {userEntity.Username} has been updated");
    }

    public async Task<Result<UserViewModel>> GetUserDetails(Guid userId)
    {
        var userDetails = await _userRepository.FindDetailsAsync(userId);
        if (userDetails == null)
            return Result<UserViewModel>.Fail("User not found");
        return Result<UserViewModel>.Success(userDetails);
    }

    public async Task<Result<ElderlyCareSupport.Domain.Entities.Identity.User>> GetUser(Guid userId)
    {
        var user = await _userRepository.FindAsync(userId);
        if (user == null)
            return Result<ElderlyCareSupport.Domain.Entities.Identity.User>.Fail("User not found");
        return Result<ElderlyCareSupport.Domain.Entities.Identity.User>.Success(user);
    }

    public async Task<Result> DeleteUser(Guid userId)
    {
        var validUser = await _userRepository.ExistsAsync(userId);
        if (!validUser)
            return Result.Fail("User not found");
        
        var user = await _userRepository.DeleteAsync(userId);
        if(user is null)
            return Result.Fail("Error Deleting  User");
        
        return Result.Success($"User {user.Username} has been deleted");
    }
}