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
            if (_accessor.HttpContext.Session.GetString("role") == "user")
            {
                return RedirectToAction("NoAccess", "Home");
            }

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
            if (_accessor.HttpContext.Session.GetString("role") == "user")
            {
                return RedirectToAction("NoAccess", "Home");
            }

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
            if (_accessor.HttpContext.Session.GetString("role") == "user")
            {
                return RedirectToAction("NoAccess", "Home");
            }

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

        public async Task<IActionResult> MySubmissions()
        {
            CommonViewModel model = new CommonViewModel()
            {
                tickets = await _ticketProcessor.LoadTickets(),
                ticketTypes = await _ticketProcessor.LoadTypes(),
                jurisdictions = await _jurisdictionProcessor.LoadJurisdictions(),
                username = _accessor.HttpContext.Session.GetString("username")
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
            

            var username = _accessor.HttpContext.Session.GetString("username");
            CommonViewModel model = new CommonViewModel()
            {
                ticketTypes = await _ticketProcessor.LoadTypes(),
                jurisdictions = await _jurisdictionProcessor.LoadJurisdictions(),
                role = _accessor.HttpContext.Session.GetString("role"),
                ticket = new Ticket() {WhoSubmitted = username}
            };

            if (model.ticketTypes == null)
            {
                return RedirectToAction("Login", "Login");
            }


            return View(model);
        }

        //CREATING A NEW ESCALATION

        [HttpPost]
        public async Task<IActionResult> New(Ticket ticket)
        {
            
            var result = await _ticketProcessor.SaveTicket(ticket);
            var x = _accessor.HttpContext.Session.GetString("token");
            if(!String.IsNullOrEmpty(result))
            {
                return RedirectToAction("Success", "Home");
            }
            return RedirectToAction("Index");
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

            if (_accessor.HttpContext.Session.GetString("role") == "user")
            {
                if (model.ticket.WhoSubmitted != _accessor.HttpContext.Session.GetString("username"))
                {
                    return RedirectToAction("NoAccess", "Home");
                }
            }
            
            //returns null because user is not authorized for this.
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
            return RedirectToAction("Index", "Home");
        }

        [HttpDelete]
        public IActionResult DeleteTicket(Ticket ticket)
        {
            var result = _ticketProcessor.DeleteTicket(ticket);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult NewType()
        {
            if (_accessor.HttpContext.Session.GetString("role") == "user" || _accessor.HttpContext.Session.GetString("role") == "manager" )
            {
                return RedirectToAction("NoAccess", "Home");
            }

            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> NewType(TicketType ticketType)
        {
            var result = await _ticketProcessor.SaveType(ticketType);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditType(int typeId)
        {

            CommonViewModel model = new CommonViewModel()
            {

                ticketType = await _ticketProcessor.LoadType(typeId)

            };

            if (_accessor.HttpContext.Session.GetString("role") == "user" || _accessor.HttpContext.Session.GetString("role") == "manager")
            {

                return RedirectToAction("NoAccess", "Home");
  
            }
            
            //returns null because user is not authorized for this.
            return View(model);
        }

        // POST ACTION TO SAVE TYPE EDITS 
        [HttpPost]
        public async Task<IActionResult> EditType(TicketType ticketType)
        {
            var result = await _ticketProcessor.EditType(ticketType);
            return RedirectToAction("ManageTypes", "Ticket");
        }

        [HttpGet]
        public async Task<IActionResult> ManageTypes()
        {
            if (_accessor.HttpContext.Session.GetString("role") == "user" || _accessor.HttpContext.Session.GetString("role") == "manager")
            {
                return RedirectToAction("NoAccess", "Home");
            }

            CommonViewModel model = new CommonViewModel()
            {
                ticketTypes = await _ticketProcessor.LoadTypes()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteType(long id)
        {
            var result = _ticketProcessor.DeleteType(id);
            return RedirectToAction("ManageTypes", "Ticket");
        }




        
    }
}