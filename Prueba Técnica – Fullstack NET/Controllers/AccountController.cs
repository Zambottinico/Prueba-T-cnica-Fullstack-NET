using Microsoft.AspNetCore.Mvc;
using Prueba_Técnica___Fullstack_NET.Models;

namespace Prueba_Técnica___Fullstack_NET.Controllers
{
    public class AccountController : Controller
    {
        private const string RoleKey = "Role";
        private const string EmailKey = "Email";

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

            // Simulado: no valida contra BD.
            HttpContext.Session.SetString(RoleKey, model.Rol);
            HttpContext.Session.SetString(EmailKey, model.Email ?? string.Empty);

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
