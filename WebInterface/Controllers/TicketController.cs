using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Processors;
using Escalator.Common.Models;
using WebInterface.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace WebInterface.Controllers
{
    public class TicketController : Controller 
    {
        private TicketProcessor _ticketProcessor;
        private JurisdictionProcessor _jurisdictionProcessor;

        public TicketController(TicketProcessor ticketProcessor, JurisdictionProcessor jurisdictionProcessor)
        {
            _ticketProcessor = ticketProcessor;
            _jurisdictionProcessor = jurisdictionProcessor;

        }

        //INDEX PAGE SHOWING ALL TICKETS

        public async Task<IActionResult> Index()
        {

            TicketsViewModel model = new TicketsViewModel()
            {
                tickets = await _ticketProcessor.LoadTickets(),
                ticketTypes = await _ticketProcessor.LoadTypes(),
                jurisdictions = await _jurisdictionProcessor.LoadJurisdictions()
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
        public async Task<IActionResult> New(Ticket ticket)
        {
            var result = await _ticketProcessor.SaveTicket(ticket);
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