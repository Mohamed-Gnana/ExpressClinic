using ExpressClinic.SharedKernal.Abstraction.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Infrastructure.Services.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string from, string subject, string body)
        {
            var emailClient = new SmtpClient("localhost");
            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body
            };

            message.To.Add(new MailAddress(to));

            await emailClient.SendMailAsync(message);
            _logger.LogWarning(@$"Email was sent by {from} to {to}");
        }
    }
}
