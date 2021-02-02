using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Models;
using WebInterface.Processors;

namespace WebInterface.Controllers
{
    public class AgentController : Controller
    {
        private AgentProcessor _agentProcessor;
        private TicketProcessor _ticketProcessor;
        private IHttpContextAccessor _accessor;

        public AgentController(AgentProcessor agentProcessor, TicketProcessor ticketProcessor, IHttpContextAccessor accessor)
        {
            _agentProcessor = agentProcessor;
            _ticketProcessor = ticketProcessor;
            _accessor = accessor;
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
        public IActionResult Edit(string username)
        {
            var model = _agentProcessor.LoadAgent(username).Result;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Agent agent)
        {
            var result = await _agentProcessor.EditAgent(agent);
            if (result == null)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            if(_accessor.HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(string username)
        {   var agent = _agentProcessor.LoadAgent(username).Result;
            var result = _agentProcessor.DeleteAgent(agent).Result;
            return RedirectToAction("Index", "Agent");
        }


        [HttpGet] 
        public IActionResult Options()
        {
            var model = _agentProcessor.LoadAgent(_accessor.HttpContext.Session.GetString("username")).Result;
            return View(model);

        }

    }
}