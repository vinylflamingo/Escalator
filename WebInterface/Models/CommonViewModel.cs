using Escalator.Common.Models;
using System.Collections.Generic;

namespace WebInterface.Models
{
    public class CommonViewModel
    {
        public IEnumerable<Ticket> tickets;
        public IEnumerable<Agent> agents;
        public IEnumerable<Jurisdiction> jurisdictions;
        public IEnumerable<TicketType> ticketTypes;
        public Ticket ticket;
        public Agent agent;
        public Jurisdiction jurisdiction;
        public TicketType ticketType;
        public string role;
        public string username;
        
    }
}