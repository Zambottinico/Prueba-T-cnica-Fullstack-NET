using Microsoft.AspNetCore.Mvc;
using Prueba_Técnica___Fullstack_NET.Models;
using Prueba_Técnica___Fullstack_NET.Services;

namespace Prueba_Técnica___Fullstack_NET.Controllers
{
    public class AccountController : Controller
    {
        private const string RoleKey = "Role";
        private const string EmailKey = "Email";
        private readonly IUsersService _usersService;

        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _usersService.FindByEmailAndRole(model.Email, model.Rol);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas: email o rol incorrecto.");
                return View(model);
            }

            HttpContext.Session.SetString(RoleKey, user.Rol);
            HttpContext.Session.SetString(EmailKey, user.Email);

            return RedirectToAction("Index", "Users");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
