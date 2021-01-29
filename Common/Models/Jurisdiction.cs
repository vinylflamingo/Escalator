using System.ComponentModel.DataAnnotations;

namespace Escalator.Common.Models
{
    public class Jurisdiction
    {
        public long Id {get; set;}
        public string Name {get; set;}
        
        public long? DefaultAgentId {get; set;} 
        public long? DefaultManagerId {get; set;} = null;

        public long? SecondaryAgentId{get; set;} = null; // these are extra agent id slots
        public long? TertiaryAgentId{get; set;} = null;  // just incase there is multiple people working one juris.

    }
}