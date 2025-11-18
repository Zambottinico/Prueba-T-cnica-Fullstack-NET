using Dapper;
using Prueba_Técnica___Fullstack_NET.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Prueba_Técnica___Fullstack_NET.Data
{

    public class UsersRepository : IUsersRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public UsersRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<User> GetAll()
        {
            using var conn = _connectionFactory.CreateConnection();
            return conn.Query<User>("SELECT * FROM Usuarios").ToList();
        }

        public User? GetById(int id)
        {
            using var conn = _connectionFactory.CreateConnection();
            return conn.QueryFirstOrDefault<User>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
        }
        public User? GetByEmailAndRole(string email, string role)
        {
            using var conn = _connectionFactory.CreateConnection();
            const string sql = @"SELECT TOP 1 *
                         FROM Usuarios
                         WHERE Email = @Email AND Rol = @Rol";

            return conn.QueryFirstOrDefault<User>(sql, new { Email = email, Rol = role });
        }

        public int Create(User user)
        {
            using var conn = _connectionFactory.CreateConnection();
            var sql = @"INSERT INTO Usuarios (Nombre, Apellido, Documento, Email, Rol)
                    VALUES (@Nombre, @Apellido, @Documento, @Email, @Rol);
                    SELECT CAST(SCOPE_IDENTITY() as int);";
            return conn.QuerySingle<int>(sql, user);
        }

        public void Update(User user)
        {
            using var conn = _connectionFactory.CreateConnection();
            var sql = @"UPDATE Usuarios SET
                        Nombre = @Nombre,
                        Apellido = @Apellido,
                        Documento = @Documento,
                        Email = @Email,
                        Rol = @Rol
                    WHERE Id = @Id";
            conn.Execute(sql, user);
        }

        public void Delete(int id)
        {
            using var conn = _connectionFactory.CreateConnection();
            conn.Execute("DELETE FROM Usuarios WHERE Id = @Id", new { Id = id });
        }
    }

}
