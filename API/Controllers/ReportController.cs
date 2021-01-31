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
    public class ContactController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IConfiguration _config;

        public ContactController(DBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            //ticketEmails = new TicketEmails(emailService, context);
        }

        [HttpGet]
        public async Task ExecuteTestReport()
        {
            await new NewTestReport(_context, _config).Submit();
        }

    }
}
