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

namespace Escalator.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypeController : ControllerBase
    {
        private readonly DBContext _context;

        public TicketTypeController(DBContext context)
        {
            _context = context;
        }

        // GET: api/TicketType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketType>>> GetTicketTypes()
        {
            return await _context.TicketType.ToListAsync();
        }

        // GET: api/TicketType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketType>> GetTicketType(long id)
        {
            var ticket = await _context.TicketType.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/TicketType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketType(long id, TicketType ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketTypeExists(id))
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

        // POST: api/TicketType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<TicketType>> PostTicketType(TicketType ticket)
        {
            _context.TicketType.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketType", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/TicketType/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketType>> DeleteTicketType(long id)
        {
            var ticket = await _context.TicketType.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.TicketType.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        private bool TicketTypeExists(long id)
        {
            return _context.TicketType.Any(e => e.Id == id);
        }
    }
}
