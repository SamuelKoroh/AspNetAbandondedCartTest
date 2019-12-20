using AspNetAbandondedCartTest.Configuration;
using AspNetAbandondedCartTest.Core.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAbandondedCartTest.Service
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<SendGridSetting> _sendGridSetting;

        public EmailService(IOptions<SendGridSetting> sendGridSetting)
        {
            _sendGridSetting = sendGridSetting;
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var client = new SendGridClient(_sendGridSetting.Value.ApiKey);
            var from = new EmailAddress("samuel.koroh@tarvostechnology.com", "Property Pro");
            var toAddress = new EmailAddress(to);
            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, body, body);
            await client.SendEmailAsync(msg);
        }
    }
}
