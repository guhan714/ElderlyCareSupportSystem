using ElderlyCareSupport.Domain.Entities.Identity;
using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Interface.Security;
using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Implementation.Master;

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
        var userEntity = new User
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

    public async Task<Result<User>> GetUser(Guid userId)
    {
        var user = await _userRepository.FindAsync(userId);
        if (user == null)
            return Result<User>.Fail("User not found");
        return Result<User>.Success(user);
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