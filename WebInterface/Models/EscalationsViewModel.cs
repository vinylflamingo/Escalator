using Escalator.Common.Models;
using System.Collections.Generic;

namespace WebInterface.Models
{
    public class EscalationsViewModel
    {
        public IEnumerable<Escalation> escalations {get; set;}
        public IEnumerable<Jurisdiction> jurisdictions {get; set;}
        public IEnumerable<Agent> agents {get; set;}

    }
}