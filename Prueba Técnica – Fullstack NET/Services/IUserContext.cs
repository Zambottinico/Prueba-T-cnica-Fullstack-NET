namespace Prueba_Técnica___Fullstack_NET.Services
{
    public interface IUserContext
    {
        string CurrentRole { get; }
        string? Email { get; }
        bool IsAuthenticated { get; }
    }
}
