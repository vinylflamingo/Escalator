using Escalator.API.Interfaces;
using Escalator.Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escalator.API.Email
{
    
    public class TicketEmails
    {
        private readonly DBContext _context;
        private IEmailService _emailService;


        private string interfaceUrl = "https://escalatorwebinterface-alpha.azurewebsites.net";
        public TicketEmails(EmailService emailService, DBContext context)
        {
            _emailService = emailService;
            _context = context;
        }

        public async Task<string> sendNewTicketEmail(Ticket ticket)
        {

            // we've got to grab the jurisdiction object first to see if there is other agents 
            var jd = _context.Jurisdictions.Where(j => j.Id == ticket.JurisdictionId).First();
            //creating a list to add multiple agents to send same email. 
            var agentList = new List<Agent>();

            //this first agent in the list is required. 
            agentList.Add(_context.Agents.Where(u => u.Id == ticket.AssignedAgent).First());

            //now we check for other agents, if they exist we add them to the list.
            if (jd.SecondaryAgentId != null)
            {
                agentList.Add(_context.Agents.Where(u => u.Id == jd.SecondaryAgentId).First());
            }
            //one more time for the possible third agent
            if (jd.TertiaryAgentId != null)
            {
                agentList.Add(_context.Agents.Where(u => u.Id == jd.TertiaryAgentId).First());
            }


            //now we will loop through each agent, and send a email or not depending on opt. 

            foreach (var agent in agentList)
            {
                if (agent.OptInNotifications == true)
                {
                    var jurisdiction = jd.Name.ToString();
                    var ticketType = _context.TicketType.Where(t => t.Id == ticket.ticketType).First().Type;
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

                    try 
                    {
                        await _emailService.Send(agentEmail, subject, content);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }                   
                }


            }
            


            return "sent";
        }
    }
}