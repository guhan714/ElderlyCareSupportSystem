namespace ElderlyCareSupportSystem.Infrastructure.Security.Contract;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}