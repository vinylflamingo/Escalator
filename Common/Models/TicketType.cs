namespace Escalator.Common.Models
{
    public class TicketType
    {
        public long Id { get; set;}
        public string Type {get; set;}
        public bool formJurisdiction {get; set;}
        public bool formStatus {get; set;}
        public bool formSeverity {get; set;}
        public bool formAssignedAgent {get; set;}
        public bool formCompletedBy {get; set;}
        public bool formDueDate {get; set;}
        public bool formPhoneNumber {get; set;}
        public bool formEmailAddress {get; set;}
        public bool formOriginalAccount {get; set;}
        public bool formMoveToAccount {get; set;}
        public bool formInvoices {get; set;}
        public bool formMarkComplete {get; set;}
        public bool formDetails {get; set;}

    }
}