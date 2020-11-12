using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Basic.Controllers
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


        public IActionResult Authenticate()
        {
            var cookieAuth = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Ranga"),
                new Claim(ClaimTypes.Email, "ranga@somedomain.com"),
                new Claim("NickName", "Benji")

            };

            var cookieAuthIdentity = new ClaimsIdentity(cookieAuth, "selfIdentity");
            var userPrincipal  = new ClaimsPrincipal(new [] { cookieAuthIdentity});

            return RedirectToAction("Index");
        }
    }
}
