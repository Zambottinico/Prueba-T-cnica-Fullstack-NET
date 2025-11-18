using Prueba_Técnica___Fullstack_NET.Models;

namespace Prueba_Técnica___Fullstack_NET.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetUsers(string currentRole);
        User? GetById(int id);
        int Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
