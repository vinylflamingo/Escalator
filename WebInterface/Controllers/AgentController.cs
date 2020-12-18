using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Models;
using WebInterface.Processors;

namespace WebInterface.Controllers
{
    public class AgentController : Controller
    {
        private AgentProcessor _agentProcessor;
        public AgentController(AgentProcessor agentProcessor)
        {
            _agentProcessor = agentProcessor;
        }

        public async Task<IActionResult> Index()
        {

            AgentsViewModel model = new AgentsViewModel()
            {
                agents = await _agentProcessor.LoadAgents()
            };
            

            return View(model);
        }


        [HttpGet]
        public IActionResult New()
        {
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> New(Agent agent)
        {       
            var result = await _agentProcessor.SaveAgent(agent);
            if (result == null)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult ResetPassword(Agent agent)
        {
            return View(agent);
        }

        [HttpPost] 
        public IActionResult PostNewPassword(Agent agent)
        {
            var result = _agentProcessor.NewPassword(agent);
            return RedirectToAction("Index", "Ticket");
        }


    }
}