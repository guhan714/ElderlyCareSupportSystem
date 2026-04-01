namespace ElderlyCareSupportSystem.Infrastructure.Externals;

public interface IEmailService
{
    Task SendEmailAsync(string userName, string email, string subject, string message);
}