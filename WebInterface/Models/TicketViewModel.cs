using Escalator.Common.Models;
using System.Collections.Generic;

namespace WebInterface.Models
{
    public class TicketViewModel
    
    {
        public Ticket ticket{get; set;}
        public IEnumerable<Jurisdiction> jurisdictions {get; set;}
        public IEnumerable<Agent> agents {get; set;}
        public IEnumerable<TicketType> ticketTypes {get; set;}

    }
}