using Prueba_Técnica___Fullstack_NET.Data;
using Prueba_Técnica___Fullstack_NET.Models;
using System.Collections.Generic;
using System.Linq;
namespace Prueba_Técnica___Fullstack_NET.Services
{

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repo;
        public UsersService(IUsersRepository repo)
        {
            _repo = repo;
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
        public int Create(User user) => _repo.Create(user);
        public void Update(User user) => _repo.Update(user);
        public void Delete(int id) => _repo.Delete(id);
    }
}
