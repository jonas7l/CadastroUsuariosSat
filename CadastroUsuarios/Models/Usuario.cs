using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CadastroUsuarios.Models
{
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public string Nome { get; set; }
    }
}
