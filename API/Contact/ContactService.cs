using Escalator.Common.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Escalator.API.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Escalator.API.Contact
{
    public class ContactService
    {      
        private readonly DBContext _context;
        private readonly IConfiguration _configuration;
        private readonly string host;
        private readonly int port;
        private readonly string user;
        private readonly string password;
        private readonly string fromAddress;  
        
        public ContactService(DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            fromAddress = _configuration["EmailServer:FromAddress"];
            host = _configuration["EmailServer:SmtpHost"];
            port = int.Parse(_configuration["EmailServer:SmtpPort"]);
            user = _configuration["EmailServer:SmtpUser"];
            password = _configuration["EmailServer:SmtpPassword"];
        }
        
        public ContactRecord CreateNewRecord(string recordType, string to, string subject, string html)
        {
            return new ContactRecord() {
                Created = DateTime.UtcNow,
                Type = recordType,
                SentTo = to,
                Subject = subject, 
                Body = html
            };

        }

        public async Task Send(ContactRecord record)
        {
            var agent = _context.Agents.Where(x => x.Email == record.SentTo).First();
            if (record.Type == "Notification") 
            {
                if (!CheckOptInNotifications(agent)) return;
            }
            if (record.Type == "Report") 
            {
                if (!CheckOptInReports(agent)) return;
            }
            
            //create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(fromAddress));
            email.To.Add(MailboxAddress.Parse(record.SentTo));
            email.Subject = record.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = record.Body };
            

            //send email

            using var smtp = new SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.StartTlsWhenAvailable);
            smtp.Authenticate(user, password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        



        public async Task Save(ContactRecord record)
        {
            _context.ContactRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        bool CheckOptInNotifications(Agent agent)
        {
            if (agent.OptInNotifications == true)
            {
                return true;
            }
            return false;
        }

        bool CheckOptInReports(Agent agent)
        {
            if (agent.OptInReports == true)
            {
                return true;
            }
            return false;
        }
        
    }

    
}