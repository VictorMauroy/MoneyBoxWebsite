using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MoneyBoxWebsite.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _configuration["SendGridApiKey"]; // Retrieve your SendGrid API key from configuration
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("your-email@example.com", "Your Name");
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);
            await client.SendEmailAsync(msg);
        }
    }

}
