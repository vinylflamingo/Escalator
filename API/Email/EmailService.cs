using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Escalator.API.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Escalator.API.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string host;
        private readonly int port;
        private readonly string user;
        private readonly string password;
        private readonly string fromAddress;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            fromAddress = _configuration["EmailServer:FromAddress"];
            host = _configuration["EmailServer:SmtpHost"];
            port = int.Parse(_configuration["EmailServer:SmtpPort"]);
            user = _configuration["EmailServer:SmtpUser"];
            password = _configuration["EmailServer:SmtpPassword"];
        }

        public string Send(string to, string subject, string html)
        {
            //create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(fromAddress));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            //send email

            using var smtp = new SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.StartTlsWhenAvailable);
            smtp.Authenticate(user, password);
            smtp.Send(email);
            smtp.Disconnect(true);



            return "";
        }

    }
}