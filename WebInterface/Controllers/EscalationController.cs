using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Processors;
using Escalator.Common.Models;
using WebInterface.Models;
using Microsoft.AspNetCore.Http;
using System;

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
        public async Task<IActionResult> New(Escalation escalation)
        {
            var result = await EscalationProcessor.SaveEscalation(escalation);
            return View();

            //more manual way of making model object from form collection.
            //Trying more efficient methods and only using this as backup


            //Escalation escalation = new Escalation()
            //{
            //    JurisdictionID = Convert.ToInt32(collection["JurisdictionID"]),
            //    Account = collection["Account"],
            //    DueBy = ),
            //};
        }


        
    }
}