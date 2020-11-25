using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escalator;
using Escalator.Common.Models;

namespace Escalator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscalationController : ControllerBase
    {
        private readonly DBContext _context;

        public EscalationController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Escalation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escalation>>> GetEscalations()
        {
            return await _context.Escalations.ToListAsync();
        }

        // GET: api/Escalation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escalation>> GetEscalation(long id)
        {
            var escalation = await _context.Escalations.FindAsync(id);

            if (escalation == null)
            {
                return NotFound();
            }

            return escalation;
        }

        // PUT: api/Escalation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEscalation(long id, Escalation escalation)
        {
            if (id != escalation.Id)
            {
                return BadRequest();
            }

            _context.Entry(escalation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EscalationExists(id))
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

        // POST: api/Escalation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Escalation>> PostEscalation(Escalation escalation)
        {
            _context.Escalations.Add(escalation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEscalation", new { id = escalation.Id }, escalation);
        }

        // DELETE: api/Escalation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Escalation>> DeleteEscalation(long id)
        {
            var escalation = await _context.Escalations.FindAsync(id);
            if (escalation == null)
            {
                return NotFound();
            }

            _context.Escalations.Remove(escalation);
            await _context.SaveChangesAsync();

            return escalation;
        }

        private bool EscalationExists(long id)
        {
            return _context.Escalations.Any(e => e.Id == id);
        }
    }
}
