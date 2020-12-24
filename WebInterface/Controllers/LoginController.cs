using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Processors;

namespace WebInterface.Controllers
{
    public class LoginController : Controller
    {   
        private LoginProcessor _login;
        private AgentProcessor _agentProcessor;

        public LoginController(LoginProcessor login, AgentProcessor agentProcessor)
        {
            _login = login;
            _agentProcessor = agentProcessor;
        }

        [HttpGet]
        public IActionResult Login(int? code)
        {
            if(code == 1)
            {
                ViewBag.Message = "Invalid credentials. Please try again.";
            }
            UserCred model = new UserCred();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserCred userCred)
        {
            var result = await _login.Login(userCred);
            if (result == null)
            {
                return RedirectToAction("Login", "Login", 1);
            }

            Debug.WriteLine("RESULT : "+result); 
            var agent = _agentProcessor.LoadAgent(userCred.Username);
            if (agent.Result.NeedsNewPassword)
            {
                return RedirectToAction("ResetPassword", "Agent", agent.Result);
            }
            return RedirectToAction("MyTickets", "Ticket");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _login.Logout();
            return View();
        }




    }
}