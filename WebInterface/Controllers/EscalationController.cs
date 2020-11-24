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

        //INDEX PAGE SHOWING ALL ESCALATIONS

        public async Task<IActionResult> Index()
        {

            EscalationsViewModel model = new EscalationsViewModel()
            {
                escalations = await EscalationProcessor.LoadEscalations(),
                agents = 
                {
                    new Agent(){ Id = 1, Username = "Agent One", }
                }
                

            };

            return View(model);
        }

        //PAGE SHOWING FORM TO CREATE NEW RECORD

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }



        //CREATING A NEW ESCALATION

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