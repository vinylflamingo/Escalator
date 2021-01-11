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
    [Route("api/[controller]")]
    [ApiController]
    public class JurisdictionController : ControllerBase
    {
        private readonly DBContext _context;

        public JurisdictionController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Jurisdiction
        [Authorize(Roles="user,manager,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jurisdiction>>> GetJurisdictions()
        {
            return await _context.Jurisdictions.ToListAsync();
        }

        // GET: api/Jurisdiction/5
        [Authorize(Roles="user,manager,admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Jurisdiction>> GetJurisdiction(long id)
        {
            var jurisdiction = await _context.Jurisdictions.FindAsync(id);

            if (jurisdiction == null)
            {
                return NotFound();
            }

            return jurisdiction;
        }

        // PUT: api/Jurisdiction/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJurisdiction(long id, Jurisdiction jurisdiction)
        {
            if (id != jurisdiction.Id)
            {
                return BadRequest();
            }

            _context.Entry(jurisdiction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JurisdictionExists(id))
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

        // POST: api/Jurisdiction
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Jurisdiction>> PostJurisdiction(Jurisdiction jurisdiction)
        {
            _context.Jurisdictions.Add(jurisdiction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJurisdiction", new { id = jurisdiction.Id }, jurisdiction);
        }

        // DELETE: api/Jurisdiction/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jurisdiction>> DeleteJurisdiction(long id)
        {
            var jurisdiction = await _context.Jurisdictions.FindAsync(id);
            if (jurisdiction == null)
            {
                return NotFound();
            }

            _context.Jurisdictions.Remove(jurisdiction);
            await _context.SaveChangesAsync();

            return jurisdiction;
        }

        private bool JurisdictionExists(long id)
        {
            return _context.Jurisdictions.Any(e => e.Id == id);
        }
    }
}
