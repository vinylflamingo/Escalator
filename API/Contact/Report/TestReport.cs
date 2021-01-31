using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escalator.API.Contact;
using Escalator.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Escalator.API.Contact.Report
{
    public class TestReport : IContact
    {

        public ContactService contactService;
        public DBContext _context;
        public List<ContactRecord> newMessages;

        public TestReport(DBContext context, IConfiguration config)
        {
            contactService = new ContactService(context, config);
            _context = context;
            newMessages = CreateMessages();
        }

        public List<ContactRecord> CreateMessages()
        {

            var agents = _context.Agents;
            var jurisdictions = _context.Jurisdictions;
            var tickets = _context.Tickets;

            var recordList = new List<ContactRecord>();
            var ticketTypes = _context.TicketType;

            foreach (var agent in agents)
            {
                var outstandingTickets = tickets.Where(x => x.AssignedAgent == agent.Id);
                var outstandingTypes = new Dictionary<string, int>();
                var closedByAgent = tickets.Where(x => x.CompletedBy == agent.Id);
                var submittedStillOpen = tickets.Where(x => x.IsCompleted == true).Where(x => x.WhoSubmitted == agent.Username);
                var subscribedJurisdictions = new List<Jurisdiction>();
                foreach(var ticket in outstandingTickets)
                {
                    var type = ticketTypes.Where(t => t.Id == ticket.ticketType).First();
                    if (!outstandingTypes.ContainsKey(type.Type))
                    {
                        outstandingTypes.Add(type.Type, 1);
                    }
                    else 
                    {
                        int count; 
                        outstandingTypes.TryGetValue(type.Type, out count);
                        count++;
                        Debug.WriteLine(count);
                        outstandingTypes[type.Type] = count;
                    }
                        
                }         
                foreach(var jd in jurisdictions.Where(x => x.DefaultAgentId == agent.Id))
                {
                    subscribedJurisdictions.Add(jd);
                }
                foreach(var jd in jurisdictions.Where(x => x.SecondaryAgentId == agent.Id))
                {
                    subscribedJurisdictions.Add(jd);
                }
                foreach(var jd in jurisdictions.Where(x => x.TertiaryAgentId == agent.Id))
                {
                    subscribedJurisdictions.Add(jd);
                }
                    

                
                //     string interfaceUrl = "https://escalatorwebinterface-alpha.azurewebsites.net";
                var agentEmail = agent.Email;
                var subject = $"Your Ticket Report";
                var content = $@"<h1>Hello, {agent.Username}!</h1>
                                 <strong>This is a test of the Reporting System</strong>><br><br>";
                var record = contactService.CreateNewRecord("Report", agentEmail, subject, content);
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