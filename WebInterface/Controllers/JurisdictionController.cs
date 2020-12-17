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

        public JurisdictionController(JurisdictionProcessor jurisdictionProcessor)
        {
            _jurisdictionProcessor = jurisdictionProcessor;

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
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> New(Jurisdiction jurisdiction)
        {       
            var result = await _jurisdictionProcessor.SaveJurisdiction(jurisdiction);
            return RedirectToAction("Index");

        }
    }
}