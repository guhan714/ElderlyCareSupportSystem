namespace ElderlyCareSupportSystem.Infrastructure.Modules.Services.Contracts;

public interface IEmailService
{
    Task SendEmailAsync(string userName, string email, string subject, string message);
}