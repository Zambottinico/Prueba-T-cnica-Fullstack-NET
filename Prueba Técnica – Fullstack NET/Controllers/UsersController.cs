using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var users = _usersService.GetUsers(CurrentRole);
            return View(users);
        }
    }
}
