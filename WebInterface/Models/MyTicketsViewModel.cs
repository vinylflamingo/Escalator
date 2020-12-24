using Escalator.Common.Models;
using System.Collections.Generic;

namespace WebInterface.Models
{
    public class MyTicketsViewModel
    
    {
        public IEnumerable<Ticket> tickets {get; set;}
        public IEnumerable<Jurisdiction> jurisdictions {get; set;}
        public IEnumerable<TicketType> ticketTypes {get; set;}
        public long AgentId {get;set;}

    }
}