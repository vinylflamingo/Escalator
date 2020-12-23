using System.Collections.Generic;
using Escalator.Common.Models;

namespace WebInterface.Models
{
    public class JurisdictionViewModel
    {
        public Jurisdiction jurisdiction {get; set;}
        public IEnumerable<Agent> agents {get; set;}
    }
}