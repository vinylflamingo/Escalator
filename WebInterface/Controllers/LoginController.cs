using System;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Mvc;
using WebInterface.Processors;

namespace WebInterface.Controllers
{
    public class LoginController : Controller
    {
        LoginProcessor loginProcessor = new LoginProcessor();

        [HttpGet]
        public IActionResult Login()
        {
            UserCred model = new UserCred();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserCred userCred)
        {
            var result = await loginProcessor.Login(userCred);
            Console.WriteLine(result.ToString());
            return View();
        }


    }
}