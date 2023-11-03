using System.ComponentModel.DataAnnotations;

namespace MeuSitemMVC.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter contact Name! ")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Enter the Email contact!")]
        [EmailAddress(ErrorMessage ="Email is not valid!")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Enter the phone contact!")]
        [Phone(ErrorMessage = "The number is not valid!")]
        public string Celular { get; set; }
    }
}
