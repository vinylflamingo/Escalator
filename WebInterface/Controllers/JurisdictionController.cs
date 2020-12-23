using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Models;
using WebInterface.Processors;

namespace WebInterface.Controllers
{
    public class JurisdictionController : Controller
    {
        private JurisdictionProcessor _jurisdictionProcessor;
        private AgentProcessor _agentProcessor;

        public JurisdictionController(JurisdictionProcessor jurisdictionProcessor, AgentProcessor agentProcessor)
        {
            _jurisdictionProcessor = jurisdictionProcessor;
            _agentProcessor = agentProcessor;

        }
        
        public async Task<IActionResult> Index()
        {

            JurisdictionsViewModel model = new JurisdictionsViewModel()
            {
                jurisdictions = await _jurisdictionProcessor.LoadJurisdictions()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult New()
        {
            JurisdictionViewModel model = new JurisdictionViewModel()
            {
                agents = _agentProcessor.LoadAgents().Result
            };
            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> New(Jurisdiction jurisdiction)
        {       
            var result = await _jurisdictionProcessor.SaveJurisdiction(jurisdiction);
            if (result == null)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            return RedirectToAction("Index");

        }
    }
}