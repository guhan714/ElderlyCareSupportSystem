namespace ElderlyCareSupportSystem.Application.Modules.Security.Contracts;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}