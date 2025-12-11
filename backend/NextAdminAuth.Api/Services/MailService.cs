using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using NextAdminAuth.Api.Models;

namespace NextAdminAuth.Api.Services;

public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;

    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
        email.To.Add(MailboxAddress.Parse(toEmail));
        email.Subject = subject;

        var builder = new BodyBuilder
        {
            HtmlBody = body
        };
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        try
        {
            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
        }
        catch (Exception ex)
        {
            // Loglama yapılabilir
            Console.WriteLine($"Mail gönderilemedi: {ex.Message}");
            throw; // Hatayı fırlat ki çağıran yer haberdar olsun
        }
        finally
        {
            await smtp.DisconnectAsync(true);
        }
    }
}

