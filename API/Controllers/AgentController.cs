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
    public class AgentController : ControllerBase
    {
        private readonly DBContext _context;

        public AgentController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Agent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
            return await _context.Agents.ToListAsync();
        }

        // GET: api/Agent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agent>> GetAgent(long id)
        {
            var agent = await _context.Agents.FindAsync(id);

            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }

        
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred) 
        {
            return Ok();
        }





 
        private bool AgentExists(long id)
        {
            return _context.Agents.Any(e => e.Id == id);
        }
    }
}
