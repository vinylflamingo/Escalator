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
        public IEnumerable<ReportSchedule> reportSchedules;
        public IEnumerable<ContactRecord> contactRecords;
        public Ticket ticket;
        public Agent agent;
        public Jurisdiction jurisdiction;
        public TicketType ticketType;
        public ReportSchedule reportSchedule;
        public ContactRecord contactRecord;
        public string role;
        public string username;
        public long AgentId;
        
    }
}