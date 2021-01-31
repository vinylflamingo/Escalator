using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escalator.API.Contact;
using Escalator.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Escalator.API.Contact.Notification
{
    public class TicketNotification : IContact
    {

        public ContactService contactService;
        public Ticket ticket;
        public DBContext context;
        public List<ContactRecord> newMessages;

        public TicketNotification(Ticket _ticket, DBContext _context, IConfiguration config)
        {
            contactService = new ContactService(_context, config);
            context = _context;
            ticket = _ticket;
            newMessages = CreateMessages();
        }

        public List<ContactRecord> CreateMessages()
        {
            // we've got to grab the jurisdiction object first to see if there is other agents 
            var jd = context.Jurisdictions.Where(j => j.Id == ticket.JurisdictionId).First();
            //creating a list to add multiple agents to send same email. 
            var agentList = new List<Agent>();

            //this first agent in the list is required. 
            agentList.Add(context.Agents.Where(u => u.Id == ticket.AssignedAgent).First());

            //now we check for other agents, if they exist we add them to the list.
            if (jd.SecondaryAgentId != null)
            {
                agentList.Add(context.Agents.Where(u => u.Id == jd.SecondaryAgentId).First());
            }
            //one more time for the possible third agent
            if (jd.TertiaryAgentId != null)
            {
                agentList.Add(context.Agents.Where(u => u.Id == jd.TertiaryAgentId).First());
            }

            var recordList = new List<ContactRecord>();

            foreach (var agent in agentList)
            {
                string interfaceUrl = "https://escalatorwebinterface-alpha.azurewebsites.net";
                var jurisdiction = jd.Name.ToString();
                var ticketType = context.TicketType.Where(t => t.Id == ticket.ticketType).First().Type;
                var agentEmail = agent.Email;
                var subject = $"New ticket on Escalator - {jurisdiction.ToString()}";
                var content = $@"<h1>Hello, {agent.Username}!</h1>
                            <p>A new {ticketType.ToString()} ticket has been submitted for you.</p><br><br>
                            <strong>{jurisdiction.ToString()}</strong>
                            <p>ID: {ticket.Id}</p>
                            <p>OPENED: {ticket.OpenDate.ToString()}</p>
                            <p>DUE: {ticket.DueBy.ToString()}</p>
                            <p>ACCOUNT: {ticket.OriginalAccount}</p>
                            <p>DETAILS: {ticket.Details}</p>
                            <a href=""{interfaceUrl}/Ticket/AdminEdit?ticketId={ticket.Id}"" <p>View this ticket</p> </a>";                 
                var record = contactService.CreateNewRecord("Notification", agentEmail, subject, content);
                recordList.Add(record);
            }
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