
using HR_Managment.Application.Contracts.Infrastructure;
using HR_Managment.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR_managment.Infrastructure.Mail
{
    public class MailSender : IEmailSender
    {
        private readonly EmailSetting _emailSettings;

        public MailSender(IOptions<EmailSetting> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress()
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var responce = await client.SendEmailAsync(message);
            return (responce.StatusCode == System.Net.HttpStatusCode.OK) || (responce.StatusCode == System.Net.HttpStatusCode.Accepted);


        }
    }
}
