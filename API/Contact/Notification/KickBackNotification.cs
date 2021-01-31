using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.Extensions.Configuration;

namespace Escalator.API.Contact.Notification
{
    public class KickBackNotification : IContact
    {
        public ContactService contactService;
        public Ticket ticket;
        public DBContext context;
        public List<ContactRecord> newMessages;

        public KickBackNotification(Ticket _ticket, DBContext _context, IConfiguration config)
        {
            contactService = new ContactService(_context, config);
            context = _context;
            ticket = _ticket;
            newMessages = CreateMessages();
        }

        public List<ContactRecord> CreateMessages()
        {
            var submittedUser = context.Agents.Where(x => x.Username == ticket.WhoSubmitted).First();

            var recordList = new List<ContactRecord>();

            string interfaceUrl = "https://escalatorwebinterface-alpha.azurewebsites.net";

            var jd  = context.Jurisdictions.Where(x => x.Id == ticket.JurisdictionId).First();


            var agentEmail = submittedUser.Email;
            var subject = $"Your submitted ticket needs more information.";
            var content = $@"<h1>Hello, {submittedUser.Username}!</h1>
                        <p>Your submitted ticket requires more info.</p><br><br>
                        <p>Please view the details </p>
                        <p>Ticket information:</p>
                        <p>ID: {ticket.Id}</p>
                        <p>OPENED: {ticket.OpenDate.ToString()}</p>
                        <p>JURISDICTION: {jd.Name}</p>
                        <p>ACCOUNT: {ticket.OriginalAccount}</p>
                        <p>DETAILS: {ticket.Details}</p>
                        <a href=""{interfaceUrl}/Ticket/AdminEdit?ticketId={ticket.Id}"" <p>View this ticket</p> </a>";                 
                var record = contactService.CreateNewRecord("Notification", agentEmail, subject, content);
                recordList.Add(record);
                return recordList;
        }

        public async Task Submit()
        {
            foreach (ContactRecord msg in newMessages)
            {
                await contactService.Send(msg);
                await contactService.Save(msg);

            }
        }
    }
}