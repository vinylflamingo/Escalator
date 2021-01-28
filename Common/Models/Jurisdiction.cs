using System.ComponentModel.DataAnnotations;

namespace Escalator.Common.Models
{
    public class Jurisdiction
    {
        public long Id {get; set;}
        public string Name {get; set;}
        
        [Required]
        public long DefaultAgentId {get; set;} 
        public long? DefaultManagerId {get; set;} = null;

        public long? SecondaryAgentId{get; set;} = null;
        public long? TertiaryAgentId{get; set;} = null;

    }
}