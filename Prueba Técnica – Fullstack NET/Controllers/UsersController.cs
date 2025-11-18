using Microsoft.AspNetCore.Mvc;
using Prueba_Técnica___Fullstack_NET.Models;
using Prueba_Técnica___Fullstack_NET.Services;

namespace Prueba_Técnica___Fullstack_NET.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IUserContext _userContext;


        public UsersController(IUsersService usersService, IUserContext userContext)
        {
            _usersService = usersService;
            _userContext = userContext;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_userContext.CurrentRole != "Administrador")
                return Forbid();
            _usersService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (_userContext.CurrentRole != "Administrador")
                return Forbid();
            if (!ModelState.IsValid)
                return View(user);

            _usersService.Create(user);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (_userContext.CurrentRole != "Administrador")
                return Forbid();
            var user = _usersService.GetById(id);
            if (user == null)
                return NotFound();

            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (_userContext.CurrentRole != "Administrador")
                return Forbid();
            if (!ModelState.IsValid)
                return View(user);

            _usersService.Update(user);
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            var users = _usersService.GetUsers(_userContext.CurrentRole);
            return View(users);
        }
        public IActionResult Create()
        {
            if (_userContext.CurrentRole != "Administrador")
                return Forbid();
            return View();
        }

    }
}
