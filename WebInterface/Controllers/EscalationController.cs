using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Processors;
using Escalator.Common.Models;

namespace WebInterface.Controllers
{
    public class EscalationController : Controller 
    {


        public IActionResult Index()
        {

            Escalation model = EscalationProcessor.LoadEscalation(1).Result; 
            return View(model);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New()
        {
            return View();
        }


        
    }
}