using DotnetDeskCore3.Data;
using DotnetDeskCore3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetDeskCore3.Services
{
    public interface IDotnetdesk
    {
        Task<bool> IsAccountActivatedAsync(string email, UserManager<ApplicationUser> userManager);

        Task SendEmailByGmailAsync(string fromEmail,
            string fromFullName,
            string subject,
            string messageBody,
            string toEmail,
            string toFullName,
            string smtpUser,
            string smtpPassword,
            string smtpHost,
            int smtpPort,
            bool smtpSSL);

        Task CreateDefaultOrganization(string applicationUserId,
            ApplicationDbContext context);

        [System.Obsolete]
        Task<string> UploadFile(List<IFormFile> files, IHostingEnvironment env);

    }
}
