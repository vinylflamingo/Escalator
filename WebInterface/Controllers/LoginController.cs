using System;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Processors;

namespace WebInterface.Controllers
{
    public class LoginController : Controller
    {   
        private LoginProcessor _login;

        public LoginController(LoginProcessor login)
        {
            _login = login;
        }

        [HttpGet]
        public IActionResult Login()
        {
            UserCred model = new UserCred();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserCred userCred)
        {
            var result = await _login.Login(userCred);
            string s = "dog house";
            ViewBag.Result = s;
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _login.Logout();
            return View();
        }




    }
}