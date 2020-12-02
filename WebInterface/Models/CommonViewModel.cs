using Escalator.Common.Models;
using System.Collections.Generic;

namespace WebInterface.Models
{
    public class CommonViewModel
    {
        public IEnumerable<Ticket> Tickets;
        public IEnumerable<Agent> Agents;
        public IEnumerable<Jurisdiction> Jurisdictions;
        public Ticket Ticket;
        public Agent Agent;
        public Jurisdiction Jurisdiction;
        
    }
}