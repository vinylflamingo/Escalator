using Escalator.API.Interfaces;
using Escalator.Common.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escalator.API.Email
{
    
    public class TicketEmails
    {
        private readonly DBContext _context;
        private IEmailService _emailService;

        private string interfaceUrl = "escalatorwebinterface-alpha.azurewebsites.net";
        public TicketEmails(EmailService emailService, DBContext context)
        {
            _emailService = emailService;
            _context = context;
        }

        public void sendNewTicketEmail(Ticket ticket)
        {
            var jurisdiction = _context.Jurisdictions.Where(j => j.Id == ticket.JurisdictionId).First().Name.ToString();
            var agent = _context.Agents.Where(u => u.Id == ticket.AssignedAgent).First();
            var ticketType = _context.TicketType.Where(t => t.Id == ticket.ticketType).First().Type;
            var agentEmail = agent.Email;
            var subject = $"New ticket on Escalator - {jurisdiction.ToString()}";
            var content = $@"<h1>Hello, {agent.Username}!</h1>
                             <p>A new {ticketType.ToString()} ticket has been submitted for you.</p><br><br>
                             <strong>{jurisdiction.ToString()}</strong>
                             <p>ID: {ticket.Id}</p>
                             <p>OPENED: {ticket.OpenDate.ToString()}</p>
                             <p>DUE: {ticket.DueBy.ToString()}</p>
                             <a href=""{interfaceUrl}/Ticket/AdminEdit?ticketId={ticket.Id}"" <p>View this ticket</p> </a>";
            try 
            {
              _emailService.Send(agentEmail, subject, content);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}