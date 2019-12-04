using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DotnetDeskCore3.Services
{
    public class EmailSender : IEmailSender
    {
        public IDotnetdesk Dotnetdesk { get; }
        public SmtpOptions SmtpOptions { get; }
        public EmailSender(IDotnetdesk dotnetdesk,
                IOptions<SmtpOptions> smtpOptions)
        {
            Dotnetdesk = dotnetdesk;
            SmtpOptions = smtpOptions.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            Dotnetdesk.SendEmailByGmailAsync(SmtpOptions.fromEmail,
                SmtpOptions.fromFullName,
                subject,
                message,
                email,
                email,
                SmtpOptions.smtpUserName,
                SmtpOptions.smtpPassword,
                SmtpOptions.smtpHost,
                SmtpOptions.smtpPort,
                SmtpOptions.smtpSSL).Wait();

            return Task.CompletedTask;
        }
    }
}
