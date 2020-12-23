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
using Escalator.API.Interfaces;

namespace Escalator.API.Controllers
{
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

        //GET A LIST OF ALL AGENTS
        // GET: api/Agent
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
            return await _context.Agents.ToListAsync();
        }

        // GET INFO FOR SINGLE AGENT
        // GET: api/Agent/5
        [Authorize]
        [HttpGet("{username}")]
        public ActionResult<Agent> GetAgent(string username)
        {
            var agent = _context.Agents.Where(u => u.Username == username).First();

            if (agent == null)
            {
                return NotFound();
            }

            return agent;
        }

        //AUTHENTICATE AGENT USING CREDENTIALS. MAIN AUTHENTICATION METHOD
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


        // POST/CREATE NEW AGENT
       // [AllowAnonymous] only needs to be enabled for initial user
        [Authorize(Roles = "admin")]
        [HttpPost("create")]
        public async Task<ActionResult<Agent>> CreateAgent(Agent agent)
        {
            
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();

            return Ok();
        }


        //EDIT EXISTING AGENT
        [Authorize]
        [HttpPut("put")]
        public async Task<IActionResult> PutAgent(Agent agent)
        {

            _context.Entry(agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(agent.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // DELETE AGENT 
        // DELETE: api/Agent/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agent>> DeleteAgent(long id)
        {
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }

            _context.Agents.Remove(agent);
            await _context.SaveChangesAsync();

            return agent;
        }
 
        private bool AgentExists(long id)
        {
            return _context.Agents.Any(e => e.Id == id);
        }
    }
}
