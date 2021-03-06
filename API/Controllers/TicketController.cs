using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escalator;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Authorization;

using Escalator.API.Interfaces;
using Escalator.API.Contact;
using Escalator.API.Contact.Notification;
using Microsoft.Extensions.Configuration;

namespace Escalator.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IConfiguration _config;

        public TicketController(DBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            //ticketEmails = new TicketEmails(emailService, context);
        }

        // GET: api/Ticket
        [Authorize(Roles="user,manager,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // GET: api/Ticket/5
        [Authorize(Roles="user,manager,admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(long id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Ticket/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles="user,manager,admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(long id, Ticket ticket)
        {


            if(ticket.Status == Status.closed)
            {
                ticket.IsCompleted = true;
            }
            else
            {
                ticket.IsCompleted = false;
            }
            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                if(ticket.Status == Status.moreinfo)
                {
                    await new KickBackNotification(ticket, _context, _config).Submit();
                }
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(ticket.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ticket
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles="user,manager,admin")]
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            ticket.AssignedAgent = _context.Jurisdictions.Where(x => x.Id == ticket.JurisdictionId).First().DefaultAgentId;
            ticket.OpenDate = DateTime.Now;
            ticket.IsCompleted = false;
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            await new TicketNotification(ticket, _context, _config).Submit();
            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Ticket/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(long id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        private bool TicketExists(long id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
