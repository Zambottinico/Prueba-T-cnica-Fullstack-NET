using System.ComponentModel.DataAnnotations;

namespace Prueba_Técnica___Fullstack_NET.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Rol { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;
    }
}
