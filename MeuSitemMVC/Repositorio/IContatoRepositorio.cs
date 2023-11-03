using MeuSitemMVC.Models;

namespace MeuSitemMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Add(ContatoModel contato);
        bool Remove(int id);
        ContatoModel Update(ContatoModel contato);

    }
}
