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
    public class MonthlyReport : IContact
    {

        public ContactService contactService;
        public DBContext _context;
        public List<ContactRecord> newMessages;

        public MonthlyReport(DBContext context, IConfiguration config)
        {
            contactService = new ContactService(context, config);
            _context = context;
            newMessages = CreateMessages();
        }

        public List<ContactRecord> CreateMessages()
        {

            var agents = _context.Agents.Where(x => x.Role == "admin"); // this limits report to admins
            var jurisdictions = _context.Jurisdictions;
            var tickets = _context.Tickets;

            var recordList = new List<ContactRecord>();
            var ticketTypes = _context.TicketType;

            Debug.WriteLine("Jurisdiction by Open Ticket Dictionary");  
            var ticketsOpen = tickets.Where(x => x.IsCompleted == false);
            var dictOpenByJuris = new Dictionary<string, int>();
            foreach(var ticket in ticketsOpen)
            {
                Jurisdiction jurisdiction;
                if (jurisdictions.Where(x => x.Id == ticket.JurisdictionId).First().Name == null)
                {
                    jurisdiction = new Jurisdiction()
                    {
                        Name = "DELETED"
                    };
                }
                else
                {
                    jurisdiction = jurisdictions.Where(x => x.Id == ticket.JurisdictionId).First();
                }
                
                if (!dictOpenByJuris.ContainsKey(jurisdiction.Name))
                {
                    Debug.WriteLine($"Adding Jurisdiction: {jurisdiction.Name}"); 
                    dictOpenByJuris.Add(jurisdiction.Name, 1);
                }
                else 
                {
                    int count; 
                    dictOpenByJuris.TryGetValue(jurisdiction.Name, out count);
                    count++;
                    Debug.WriteLine($"{jurisdiction.Name} : " + count);
                    dictOpenByJuris[jurisdiction.Name] = count;
                }
                    
            }                     
            var sortedOpenByJuris = dictOpenByJuris.OrderByDescending(x => x.Value);
    

            Debug.WriteLine("Submitted By User Dictionary");
            var dictSubmittedByUser = new Dictionary<string, int>();
            var ticketsSubmitted = tickets.Where(x => x.OpenDate > DateTime.Now.AddDays(-30));
            foreach(var ticket in ticketsSubmitted)
            {
                string user;
                if(ticket.WhoSubmitted == null) 
                {
                    user = "DELETED";
                }
                else 
                {
                    user = ticket.WhoSubmitted;
                }
                if (!dictSubmittedByUser.ContainsKey(user))
                {
                    dictSubmittedByUser.Add(user, 1);
                    
                }
                else 
                {
                    int count; 
                    dictSubmittedByUser.TryGetValue(user, out count);
                    count++;
                    Debug.WriteLine(count);
                    dictSubmittedByUser[user] = count;
                }
            }
            var sortedSubmittedByUser = dictSubmittedByUser.OrderByDescending(x => x.Value);
           
            var closedByUser = new Dictionary<string, int>();
            var ticketsCompleted = tickets.Where(x => x.CompletedDate > DateTime.Now.AddDays(-30));
            foreach(var ticket in ticketsCompleted)
            {
                Agent user;
                if (agents.Where(x => x.Id == ticket.CompletedBy).First() == null)
                {
                    user = new Agent() {Username = "DELETED"};
                }
                else 
                {
                    user = agents.Where(x => x.Id == ticket.CompletedBy).First();
                }
                if (!closedByUser.ContainsKey(user.Username))
                {
                    closedByUser.Add(user.Username, 1);
                }
                else 
                {
                    int count; 
                    closedByUser.TryGetValue(user.Username, out count);
                    count++;
                    Debug.WriteLine(count);
                    closedByUser[user.Username] = count;
                }
            }
            var sortedClosedByUser = closedByUser.OrderByDescending(x => x.Value);


            foreach (var agent in agents)
            {
                //     string interfaceUrl = "https://escalatorwebinterface-alpha.azurewebsites.net";
                var agentEmail = agent.Email;
                var subject = $"Your Monthly Overview";
                var content = $@"<h1>Hello, {agent.Username}!</h1>
                                 <strong>Monthly Report:</strong><br><br>
                                 <h3>Jurisdiction by open tickets</h3>";
                foreach(var juris in sortedOpenByJuris)
                {
                    content = content + $"<p>{juris.Key} : {juris.Value} </p>";
                }

                content = content + "<br><br><h3>30 day submission count</h3>";

                foreach(var user in sortedSubmittedByUser)
                {
                    content = content + $"<p>{user.Key} : {user.Value}</p>";
                }

                content = content + $"<br><br><h3>30 day completed count</h3>";

                foreach(var user in sortedClosedByUser)
                {
                    content = content + $"<p>{user.Key} : {user.Value}</p>";
                }

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