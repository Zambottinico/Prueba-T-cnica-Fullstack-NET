using Prueba_Técnica___Fullstack_NET.Models;

namespace Prueba_Técnica___Fullstack_NET.Data
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User? GetByEmailAndRole(string email, string role);

        int Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
