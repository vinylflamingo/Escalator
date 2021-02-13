using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Models;
using WebInterface.Processors;
using System.Linq;
using System;

namespace WebInterface.Controllers
{
    public class ReportController : Controller
    {
        private IHttpContextAccessor _accessor;
        private ReportProcessor _reportProcessor;
        private AgentProcessor _agentProcessor;

        public ReportController(ReportProcessor reportProcessor, AgentProcessor agentProcessor, IHttpContextAccessor accessor)
        {
            _reportProcessor = reportProcessor;
            _agentProcessor = agentProcessor; 
            _accessor = accessor;
        }

        /// <summary>
        /// Index view will show all ContactRecords of type Report
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            CommonViewModel model = new CommonViewModel()
            {
                contactRecords = await _reportProcessor.LoadRecords("Report")
            };
            return View(model);
        }


        //view all notifications
        [HttpGet("notifications/all")]
        public async Task<IActionResult> AllNotifications()
        {
            CommonViewModel model = new CommonViewModel()
            {
                contactRecords = await _reportProcessor.LoadRecords("Notification")
            };
            return View(model);
        }

        //view notifications generated for logged in user
        [HttpGet("notifications")]
        public async Task<IActionResult> MyNotifications()
        {
            //find the agent from the Session context 
            var agent = _agentProcessor.LoadAgent(_accessor.HttpContext.Session.GetString("username")).Result;
            var records = await _reportProcessor.LoadRecords("Notification");
            CommonViewModel model = new CommonViewModel()
            {
                contactRecords = records.Where(x => x.SentTo == agent.Email)
            };
            return View(model);
        }

        //view reports generated for logged in user
        [HttpGet("myreports")]
        public async Task<IActionResult> MyReports()
        {
            //find the agent from the Session context 
            var agent = _agentProcessor.LoadAgent(_accessor.HttpContext.Session.GetString("username")).Result;
            var records = await _reportProcessor.LoadRecords("Report");
            CommonViewModel model = new CommonViewModel()
            {
                contactRecords = records.Where(x => x.SentTo == agent.Email)
            };
            return View(model);
        }
        

        //view a single record
        [HttpGet("record/{id}")]
        public async Task<IActionResult> Record(long id)
        {
            CommonViewModel model = new CommonViewModel()
            {
                contactRecord = await _reportProcessor.LoadRecord(id)
            };
 
            return View(model);
        }

        // edit a contact record
        [HttpPost]
        public async Task<IActionResult> EditRecord(ContactRecord record)
        {
            var result = await _reportProcessor.EditRecord(record);
            return RedirectToAction("MyReports", "Report");
        }

        //manually create a new contact record

        [HttpGet]
        public IActionResult NewRecord()
        {
            return View();
        }

        //manually save a new contact record
        [HttpPost]
        public async Task<IActionResult> SaveNewRecord(ContactRecord record)
        {
            
            var result = await _reportProcessor.SaveRecord(record);
            var x = _accessor.HttpContext.Session.GetString("token");
            if(!String.IsNullOrEmpty(result))
            {
                return RedirectToAction("Success", "Home");
            }
            return RedirectToAction("NewRecord");
        }






        





       /*  [HttpGet]
        public IActionResult New()
        {
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> New(Agent agent)
        {       
            var result = await _agentProcessor.SaveAgent(agent);
            if (result == null)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(string username)
        {
            var model = _agentProcessor.LoadAgent(username).Result;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Agent agent)
        {
            var result = await _agentProcessor.EditAgent(agent);
            if (result == null)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            if(_accessor.HttpContext.Session.GetString("role") != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ResetPassword(Agent agent)
        {
            return View(agent);
        }

        [HttpPost] 
        public IActionResult PostNewPassword(Agent agent)
        {
            var result = _agentProcessor.NewPassword(agent);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(string username)
        {   var agent = _agentProcessor.LoadAgent(username).Result;
            var result = _agentProcessor.DeleteAgent(agent).Result;
            return RedirectToAction("Index", "Agent");
        }


        [HttpGet] 
        public IActionResult Options()
        {
            var model = _agentProcessor.LoadAgent(_accessor.HttpContext.Session.GetString("username")).Result;
            return View(model);

        } */

    }
}