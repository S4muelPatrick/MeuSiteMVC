using MeuSitemMVC.Enums;

namespace MeuSitemMVC.Models
{
    public class HomeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
    }
}
