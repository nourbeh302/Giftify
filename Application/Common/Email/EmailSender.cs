using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Application.Common.Email;

public class EmailSender : IEmailSender
{
    private readonly SmtpSettings _smtpSettings;

    public EmailSender(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    public async Task SendAsync(string recipient, string subject, string body)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_smtpSettings.Username, "Giftify Team"),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        mailMessage.To.Add(recipient);

        using var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password)
        };

        await smtpClient.SendMailAsync(mailMessage);
    }
}
