using Prueba_Técnica___Fullstack_NET.Data;
using Prueba_Técnica___Fullstack_NET.Models;
using System.Collections.Generic;
using System.Linq;
namespace Prueba_Técnica___Fullstack_NET.Services
{

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repo;
        private readonly IUserContext _userContext;
        public UsersService(IUsersRepository repo,IUserContext userContext)
        {
            _repo = repo;
            _userContext = userContext;

        }

        public IEnumerable<User> GetUsers(string currentRole)
        {
            var all = _repo.GetAll();

            if (currentRole == "Administrador")
                return all;

            // regla simplificada: usuario común solo ve usuarios con rol 'Usuario'
            return all.Where(u => u.Rol == "Usuario");
        }

        public User? GetById(int id) => _repo.GetById(id);
        public User? FindByEmailAndRole(string email, string role)
            => _repo.GetByEmailAndRole(email, role);

        public int Create(User user)
        {
            // Validar que no exista un usuario con el mismo email
            var existing = _repo.GetByEmail(user.Email);
            if (existing != null)
                throw new InvalidOperationException("El email ya está registrado.");

            return _repo.Create(user);
        }


        public void Update(User user)
        {
            // Validar: un usuario no puede Editarse a sí mismo
            if (string.Equals(user.Email, _userContext.Email, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("No puedes eliminar tu propio usuario.");


            _repo.Update(user);
        }
        public void Delete(int id)
        {
            // Obtener usuario a eliminar
            var user = _repo.GetById(id);
            if (user == null)
                throw new Exception("El usuario no existe.");

            // Validar: un usuario no puede eliminarse a sí mismo
            if (string.Equals(user.Email, _userContext.Email, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("No puedes eliminar tu propio usuario.");

            _repo.Delete(id);
        }
    }
}
