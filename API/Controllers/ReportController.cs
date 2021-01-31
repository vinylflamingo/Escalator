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
using Escalator.API.Contact.Report;

namespace Escalator.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IConfiguration _config;

        public ReportController(DBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            //ticketEmails = new TicketEmails(emailService, context);
        }

        //returns the current days reports that are not already executed.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportSchedule>>> Index()
        {
            return await _context.ReportSchedule.Where(x => x.Executed == false).Where(x => x.ScheduledDate.Date == DateTime.Now.Date).ToListAsync();
        }

        // returns a single specific report
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportSchedule>> GetReportSchedule(long id)
        {
            var reportSchedule = await _context.ReportSchedule.FindAsync(id);

            if (reportSchedule == null)
            {
                return NotFound();
            }

            return reportSchedule;
        }

        [HttpGet("Execute/{type}")]
        public async Task Execute(string type)
        {
            if (type == "Weekly")
            {
                await new WeeklyReport(_context, _config).Submit();
            }
            if (type == "Test")
            {
                await new TestReport(_context, _config).Submit();
            }
            if (type == "Monthly")
            {
                await new MonthlyReport(_context, _config).Submit();
            }
        }
        //generates and sends report of type Test
        [HttpGet("TestReport")]
        public async Task ExecuteTestReport()
        {
            await new TestReport(_context, _config).Submit();
        }

        //generates and sends report of type Weekly
        [HttpGet("WeeklyReport")]
        public async Task ExecuteWeeklyReport()
        {
            await new WeeklyReport(_context, _config).Submit();
        }

        //marks the report Executed
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportSchedule(ReportSchedule reportSchedule)
        {
            _context.Entry(reportSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportScheduleExists(reportSchedule.Id))
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

        //creates new report.
        [HttpPost]
        public async Task<ActionResult<ReportSchedule>> PostReportSchedule(ReportSchedule reportSchedule)
        {
            _context.ReportSchedule.Add(reportSchedule);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetReportSchedule", new { id = reportSchedule.Id }, reportSchedule);
        }

        private bool ReportScheduleExists(long id)
        {
            return _context.ReportSchedule.Any(e => e.Id == id);
        }

    }
}
