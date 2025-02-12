using System.ComponentModel.DataAnnotations;

namespace CadastroUsuarios.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }
    }
}
