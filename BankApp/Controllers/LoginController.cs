using Microsoft.AspNetCore.Mvc;
using BankApp.Services.Interfaces;

namespace BankApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IApplicationUserService _userService;

        public LoginController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userService.Login(username, password);
            if (user != null)
            {
                bool role = await _userService.GetRole(user);
                if (role) //om rollen == admin
                {
                    return RedirectToAction("AdminStart", "Admin");
                }
                else
                {
                    int id = user.CustomerID;
                    return RedirectToAction("CustomerStart", "Customer", new { ID = id });
                }
            }
            else
            {
                ViewBag.msg = "Felaktig inloggning";
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, int id, string role)
        {
            bool created = await _userService.Register(username, password, id, role);

            if (created)
            {
                return RedirectToAction("AdminStart", "Admin");
            }
            else
            {
                ViewBag.msg = "Oj! Något gick fel, alla fälten är obligatoriska";
                return View();
            }
        }
    }
}
