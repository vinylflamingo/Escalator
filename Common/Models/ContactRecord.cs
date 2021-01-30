using System;

namespace Escalator.Common.Models
{
    public class ContactRecord
    {
        public long Id {get; set;}
        public DateTime Created {get; set;}  //when the contact message was created
        public string Type {get; set;}
        public string SentTo {get; set;} //email address message was sent to 
        public string Subject {get; set;} //email subject
        public string Body {get;set;}

    }
}