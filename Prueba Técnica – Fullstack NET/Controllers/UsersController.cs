using Microsoft.AspNetCore.Mvc;
using Prueba_Técnica___Fullstack_NET.Models;
using Prueba_Técnica___Fullstack_NET.Services;

namespace Prueba_Técnica___Fullstack_NET.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        // Simulación de rol fijo
        private const string CurrentRole = "Administrador"; // o "Usuario"

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _usersService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _usersService.Create(user);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var user = _usersService.GetById(id);
            if (user == null)
                return NotFound();

            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            _usersService.Update(user);
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            var users = _usersService.GetUsers(CurrentRole);
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
