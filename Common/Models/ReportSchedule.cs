using System;
using System.ComponentModel.DataAnnotations;

namespace Escalator.Common.Models
{
    public class ReportSchedule
    {
        public long Id {get; set;}
        public string Type {get; set;}  //daily weekly yearly monthly etc.
        public bool Executed {get; set;} //determines whether report has been sent 
        public DateTime ScheduledDate {get; set;}
        public DateTime CreatedDate {get; set;}



    }
}