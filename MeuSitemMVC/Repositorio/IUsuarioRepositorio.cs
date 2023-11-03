using MeuSitemMVC.Models;

namespace MeuSitemMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Add(UsuarioModel user);
        bool Remove(int id);
        UsuarioModel Update(UsuarioModel user);

    }

}
