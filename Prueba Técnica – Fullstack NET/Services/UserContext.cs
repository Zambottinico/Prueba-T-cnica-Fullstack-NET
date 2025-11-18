namespace Prueba_Técnica___Fullstack_NET.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _accessor;
        private const string RoleKey = "Role";
        private const string EmailKey = "Email";

        public UserContext(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        private ISession? Session => _accessor.HttpContext?.Session;

        public string CurrentRole => Session?.GetString(RoleKey) ?? "Usuario";
        public string? Email => Session?.GetString(EmailKey);
        public bool IsAuthenticated => !string.IsNullOrEmpty(Session?.GetString(RoleKey));
    }
}
