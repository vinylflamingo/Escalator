using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebInterface.Controllers
{
    public class AdminController : Controller
    {

        private IHttpContextAccessor _accessor;

        public AdminController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public IActionResult Index()
        {
            var x = _accessor.HttpContext.Session.GetString("token");
            if(x == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}