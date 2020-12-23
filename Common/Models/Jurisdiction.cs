using System.ComponentModel.DataAnnotations;

namespace Escalator.Common.Models
{
    public class Jurisdiction
    {
        public long Id {get; set;}
        public string Name {get; set;}
        
        [Required]
        public long DefaultAgentId {get; set;} 
    }
}