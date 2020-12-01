using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escalator;
using Escalator.Common.Models;
using Escalator.API;
using Microsoft.AspNetCore.Authorization;

namespace Escalator.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AgentController(DBContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            this.jwtAuthenticationManager = jwtAuthenticationManager;

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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred) 
        {
            var token = jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password, _context);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

       // [AllowAnonymous] only needs to be enabled for initial user
        [HttpPost("create")]
        public async Task<ActionResult<Agent>> CreateAgent(Agent agent)
        {
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgent", new { id = agent.Id }, agent);
        }
 
        private bool AgentExists(long id)
        {
            return _context.Agents.Any(e => e.Id == id);
        }
    }
}
