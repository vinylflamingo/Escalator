using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebInterface.Models;

namespace WebInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHttpContextAccessor _accessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            if(String.IsNullOrEmpty(_accessor.HttpContext.Session.GetString("token")))
            {
                return RedirectToAction("Login", "Login");
            }
            if(_accessor.HttpContext.Session.GetString("role") == "user")
            {
                return RedirectToAction("MySubmissions", "Ticket");
            }
            return RedirectToAction("MyTickets", "Ticket");
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult NoAccess()
        {
            return View();
        }

        public IActionResult ReleaseNotes()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
