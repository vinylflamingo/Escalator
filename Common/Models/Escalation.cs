using System;

namespace Escalator.Common.Models
{
    public class Escalation
    {
        public long Id { get; set; }
        public long JurisdictionId {get; set;}
        public long AssignedAgent {get; set;}
        public long CompletedBy {get; set;}
        public DateTime OpenDate {get; set;}
        public DateTime CloseDate {get; set;}
        public DateTime DueBy {get; set;}
        public string Account {get; set;}
        public string PhoneNumber {get; set;}
        public string EmailAddress {get; set;}
        public string Details {get; set;}
    }
}