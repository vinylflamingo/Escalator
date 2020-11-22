using Escalator.Common.Models;
using System.Collections.Generic;

namespace WebInterface.Models
{
    public class CommonViewModel
    {
        public IEnumerable<Escalation> Escalations;
        public IEnumerable<Agent> Agents;
        public IEnumerable<Jurisdiction> Jurisdictions; 
        
    }
}