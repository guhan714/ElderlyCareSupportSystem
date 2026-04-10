using ElderlyCareSupportSystem.Application.Constants;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace ElderlyCareSupportSystem.Infrastructure.Externals;

public sealed class MailKitEmailService : IEmailService
{
    public async Task SendEmailAsync(string userName, string email, string subject, string message)
    {
        var mimeMessage = new MimeMessage();

        var from = new MailboxAddress(EmailConstants.SystemUserName, EmailConstants.EmailFrom);
        mimeMessage.From.Add(from);
        
        var to = new MailboxAddress(userName,email);
        mimeMessage.To.Add(to);

        mimeMessage.Subject = subject;
        mimeMessage.Body = new TextPart(TextFormat.Plain)
        {
            Text = message
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("localhost", 5039);
        await smtp.SendAsync(mimeMessage);
        await smtp.DisconnectAsync(true);
    }
}