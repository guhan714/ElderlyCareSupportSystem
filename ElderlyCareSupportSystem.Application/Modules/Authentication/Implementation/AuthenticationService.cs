using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.Authentication.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Security.Contracts;

namespace ElderlyCareSupportSystem.Application.Modules.Authentication.Implementation;

public sealed class AuthenticationService : IAuthService
{
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IHashingService _hashingService;
    
    public AuthenticationService(IAuthenticationRepository authenticationRepository, IHashingService hashingService)
    {
        _authenticationRepository = authenticationRepository;
        _hashingService = hashingService;
    }

    public async Task<Result<UserViewModel>> LoginAsync(LoginViewModel userData)
    {
        var user = await _authenticationRepository.GetAsync(userData.UserName);
        if(user is null)
            return Result<UserViewModel>.Fail("User not found");

        var isValidPassword = _hashingService.VerifyHashedPassword(user.PasswordHash, userData.Password);
        if (!isValidPassword)
            return Result<UserViewModel>.Fail("Invalid password");
        var userViewModel = new UserViewModel() { UserName = user.UserName, Email = user.Email, Role = user.Role };
        return Result<UserViewModel>.Success(userViewModel);
    }
}