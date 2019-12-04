using System.Threading.Tasks;

namespace DotnetDeskCore3.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
