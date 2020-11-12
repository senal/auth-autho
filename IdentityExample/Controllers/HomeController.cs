using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Login(string userName, string password)
        {
            return RedirectToAction("Index");
        }


        public IActionResult Register(string userName, string password)
        {
            return RedirectToAction("Index");
        }
    }
}
