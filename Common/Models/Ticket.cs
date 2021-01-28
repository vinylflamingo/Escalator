using System;

namespace Escalator.Common.Models
{
    public class Ticket
    {
        public long Id { get; set; }
        public long ticketType {get; set;}
        public long JurisdictionId {get; set;}
        public long AssignedAgent {get; set;}
        public long CompletedBy {get; set;}
        public DateTime OpenDate {get; set;}
        public bool IsCompleted {get; set;}
        public DateTime DueBy {get; set;}
        public string PhoneNumber {get; set;}
        public string EmailAddress {get; set;}
        public string OriginalAccount {get; set;}
        public string MoveToAccount {get; set;}
        public string Invoices {get; set;}
        public string Details {get; set;}
        public string WhoSubmitted {get; set;}
        public Severity Severity {get; set;}
        public Status Status {get; set;}
    }
}