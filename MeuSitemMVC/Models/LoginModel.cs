using System.ComponentModel.DataAnnotations;

namespace MeuSitemMVC.Models
{
    public class LoginModel
    {
     [Required(ErrorMessage = "User")]
     public String User { get; set; }
     [Required(ErrorMessage = "Password")]
     public String Password { get; set; }


    }
}
