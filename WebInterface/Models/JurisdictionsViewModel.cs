using System.Collections.Generic;
using Escalator.Common.Models;

namespace WebInterface.Models
{
    public class JurisdictionsViewModel
    {
        public IEnumerable<Jurisdiction> jurisdictions {get; set;}
        public IEnumerable<Agent> agents {get; set;}
    }
}