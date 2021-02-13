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

        ///<summary>
        /// First section deals with the Report Schedule and Executing reports
        ///</summary>
        //returns the current days reports that are not already executed.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportSchedule>>> Index()
        {
            return await _context.ReportSchedule.Where(x => x.Executed == false).Where(
                x => x.ScheduledDate.Date == DateTime.Now.Date 
                && 
                x.ScheduledDate.Hour == DateTime.Now.Hour )
                .ToListAsync();
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ReportSchedule>>> All()
        {
            return await _context.ReportSchedule.ToListAsync();
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
        public async Task<ActionResult> Execute(string type)
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
            return NotFound();
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

        //creates new scheduled report.
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

        ///<summary>
        /// Second section deals with the retrieving of records to be used in the interface
        ///</summary>
        //return all ContactRecords
        [HttpGet("Records/{type}")]
        public async Task<ActionResult<IEnumerable<ContactRecord>>> Records(string type = null)
        {
            if (type == null) return await _context.ContactRecords.ToListAsync();
            if (type == "Notification") return await _context.ContactRecords.Where(x => x.Type == "Notification").ToListAsync();
            if (type == "Report") return await _context.ContactRecords.Where(x => x.Type == "Report").ToListAsync();
            return NotFound();
        }

        //returns a specific record
        [HttpGet("Records/id/{id}")]
        public async Task<ActionResult<ContactRecord>> Record(long id)
        {
            var record = await _context.ContactRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return record;
        }

        //create new record 
        [HttpPost("Records")]
        public async Task<ActionResult<ContactRecord>> Record(ContactRecord contactRecord)
        {
            var contactService = new ContactService(_context, _config);
            await contactService.Save(contactRecord);
            return CreatedAtAction("Record", new {id = contactRecord.Id}, contactRecord);
        }
        [HttpPut("Records/{id}")]
        public async Task<IActionResult> PutRecord(ContactRecord contactRecord)
        {
            _context.Entry(contactRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportScheduleExists(contactRecord.Id))
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
    }
}
