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
using System.Security.Claims;
using System.Diagnostics;

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
        [Authorize(Roles="user,manager,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
            return await _context.Agents.ToListAsync();
        }

        // GET INFO FOR SINGLE AGENT
        // GET: api/Agent/5
        [Authorize(Roles="user,manager,admin")]
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
            if(SelfOrAdminCheck(agent) == false)
            {
                return Unauthorized();
            }

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
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agent>> DeleteAgent(long id)
        {
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }

            var allTickets = _context.Tickets.Where(x => x.AssignedAgent == id);
            foreach(var ticket in allTickets)
            {
                ticket.AssignedAgent = null;
                _context.Entry(ticket).State = EntityState.Modified;
            }

            var allJurisdictionsWithDefaultAgent = _context.Jurisdictions.Where(x => x.DefaultAgentId == id);
            foreach(var jurisdiction in allJurisdictionsWithDefaultAgent)
            {
                jurisdiction.DefaultAgentId = null;
                _context.Entry(jurisdiction).State = EntityState.Modified;
            }

            var allJurisdictionsWithSecondaryAgent = _context.Jurisdictions.Where(x => x.SecondaryAgentId == id);
            foreach(var jurisdiction in allJurisdictionsWithSecondaryAgent)
            {
                jurisdiction.SecondaryAgentId = null;
                _context.Entry(jurisdiction).State = EntityState.Modified;
            }

            var allJurisdictionsWithTertiaryAgent = _context.Jurisdictions.Where(x => x.TertiaryAgentId == id);
            foreach(var jurisdiction in allJurisdictionsWithTertiaryAgent)
            {
                jurisdiction.TertiaryAgentId = null;
                _context.Entry(jurisdiction).State = EntityState.Modified;
            }



            _context.Agents.Remove(agent);


            await _context.SaveChangesAsync();

            return agent;
        }
 
        private bool AgentExists(long id)
        {
            return _context.Agents.Any(e => e.Id == id);
        }

        private bool SelfOrAdminCheck(Agent agent)
        {
            var submitter = User.Claims.Where(x => x.Type == ClaimTypes.Name).First().Value;
            var role = User.Claims.Where(x => x.Type == ClaimTypes.Role).First().Value;
            var continueFlag = false;

            if (submitter == agent.Username)
            {
                continueFlag = true;
            }
            if (role == "admin")
            {
                continueFlag = true;
            }
            return continueFlag;
        }
    }
}
