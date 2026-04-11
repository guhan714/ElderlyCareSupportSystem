using ElderlyCareSupportSystem.Application.Modules.Security.Contracts;

namespace ElderlyCareSupportSystem.Infrastructure.Security.Implementation;

public sealed class BCryptHashingService : IHashingService
{
    public string HashPassword(string password)
    {
        if(password is null)
            throw new ArgumentNullException(nameof(password));
        
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        if(hashedPassword is null)
            throw new ArgumentNullException(nameof(hashedPassword));
        
        if(providedPassword is null)
            throw new ArgumentNullException(nameof(providedPassword));
        
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
}