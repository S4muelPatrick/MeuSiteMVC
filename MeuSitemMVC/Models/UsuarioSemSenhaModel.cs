using MeuSitemMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeuSitemMVC.Models
{
    //Classe criada para a edição *não editamos a senha do user junto com os demais dados*
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter user name!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Enter login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Enter user Email!")]
        [EmailAddress(ErrorMessage = "The email isn't valid!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter user position!")]
        public PerfilEnum? Perfil { get; set; }

    }
}
