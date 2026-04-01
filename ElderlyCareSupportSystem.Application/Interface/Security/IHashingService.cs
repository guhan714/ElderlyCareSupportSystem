namespace ElderlyCareSupportSystem.Application.Interface.Security;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string providedPassword);
}