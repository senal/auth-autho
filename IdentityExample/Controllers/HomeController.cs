using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var signinResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                return signinResult.Succeeded ? RedirectToAction("Index") : RedirectToAction("Index", new { status = "failed"});
            }
            return RedirectToAction("Register");

        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName, string password)
        {

            var user = new IdentityUser
            {
                UserName = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // sign the user
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
