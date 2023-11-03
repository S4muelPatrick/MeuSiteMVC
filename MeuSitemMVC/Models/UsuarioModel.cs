using MeuSitemMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuSitemMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter user name!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Enter login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Enter user Email!")]
        [EmailAddress(ErrorMessage = "The email isn't valid!")]
        public string Email { get; set; }

        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "You must enter you password!")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }


    }
}
