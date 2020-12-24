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
        private AgentProcessor _agentProcessor;
        private IHttpContextAccessor _accessor;


        public TicketController(TicketProcessor ticketProcessor, JurisdictionProcessor jurisdictionProcessor, AgentProcessor agentProcessor, IHttpContextAccessor accessor)
        {
            _ticketProcessor = ticketProcessor;
            _jurisdictionProcessor = jurisdictionProcessor;
            _agentProcessor = agentProcessor;
            _accessor = accessor;

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

            if (model.tickets == null)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            return View(model);
        }

        public async Task<IActionResult> FullHistory()
        {

            TicketsViewModel model = new TicketsViewModel()
            {
                tickets = await _ticketProcessor.LoadTickets(),
                ticketTypes = await _ticketProcessor.LoadTypes(),
                jurisdictions = await _jurisdictionProcessor.LoadJurisdictions()
            };

            if (model.tickets == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View(model);
        }

        public async Task<IActionResult> MyTickets()
        {

            MyTicketsViewModel model = new MyTicketsViewModel()
            {
                tickets = await _ticketProcessor.LoadTickets(),
                ticketTypes = await _ticketProcessor.LoadTypes(),
                jurisdictions = await _jurisdictionProcessor.LoadJurisdictions(),
                AgentId = _agentProcessor.LoadAgent(_accessor.HttpContext.Session.GetString("username")).Result.Id
            };

            if (model.tickets == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View(model);
        }

        //PAGE SHOWING FORM TO CREATE NEW RECORD

        [HttpGet]
        public async Task<IActionResult> New()
        {

            TicketViewModel model = new TicketViewModel()
            {
                ticketTypes = await _ticketProcessor.LoadTypes(),
                jurisdictions = await _jurisdictionProcessor.LoadJurisdictions()
            };
            return View(model);
        }

        //CREATING A NEW ESCALATION

        [HttpPost]
        public async Task<IActionResult> New(Ticket ticket)
        {
            
            var result = await _ticketProcessor.SaveTicket(ticket);
            var x = _accessor.HttpContext.Session.GetString("token");
            if(x == null)
            {
                return RedirectToAction("Success", "Home");
            }
            return RedirectToAction("Index");

            //more manual way of making model object from form collection.
            //Trying more efficient methods and only using this as backup


            //Escalation escalation = new Escalation()
            //{
            //    JurisdictionID = Convert.ToInt32(collection["JurisdictionID"]),
            //    Account = collection["Account"],
            //    DueBy = ),
            //};
        }

        
        //LOADS SINGLE TICKET EDIT FORM 

        [HttpGet]
        public async Task<IActionResult> AdminEdit(int ticketId)
        {

            TicketViewModel model = new TicketViewModel()
            {
                ticket = await _ticketProcessor.LoadTicket(ticketId),
                ticketTypes = await _ticketProcessor.LoadTypes(),
                jurisdictions = await _jurisdictionProcessor.LoadJurisdictions(),
                agents = await _agentProcessor.LoadAgents()
            };

            if (model.ticket == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(model);
        }

        // POST ACTION TO SAVE TICKET EDITS 
        [HttpPost]
        public async Task<IActionResult> AdminEdit(Ticket ticket)
        {
            var result = await _ticketProcessor.EditTicket(ticket);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult DeleteTicket(Ticket ticket)
        {
            var result = _ticketProcessor.DeleteTicket(ticket);
            return RedirectToAction("Index");
        }




        
    }
}