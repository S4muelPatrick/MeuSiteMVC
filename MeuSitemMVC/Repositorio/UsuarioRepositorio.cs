using MeuSitemMVC.Data;
using MeuSitemMVC.Models;


namespace MeuSitemMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataBaseContext _dataBaseContext;

        public UsuarioRepositorio(DataBaseContext bdContext)
        {
            _dataBaseContext = bdContext;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _dataBaseContext.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _dataBaseContext.Usuario.ToList();
        }

        public UsuarioModel Add(UsuarioModel user)
        {
            //Record in DataBase
            user.DataCadastro = DateTime.Now;
            _dataBaseContext.Usuario.Add(user);
            _dataBaseContext.SaveChanges();
            return user;
        }

        public UsuarioModel Update(UsuarioModel user)
        {
            UsuarioModel userDb = ListarPorId(user.Id);

            if (userDb == null)
            {
                throw new Exception("Houve um erro na atualização do usuário");
            }

            userDb.Nome = user.Nome;
            userDb.Email = user.Email;
            userDb.Login = user.Login;
            userDb.Perfil = user.Perfil;
            userDb.DataAlteracao = DateTime.Now;

            _dataBaseContext.Update(userDb);
            _dataBaseContext.SaveChanges();

            return userDb;
        }

        public bool Remove(int id)
        {
            //Delete from DataBase
            UsuarioModel userDb = ListarPorId(id);
            if (userDb == null)
            {
                throw new Exception("Houve um erro ao deletar usuário");
            }
            _dataBaseContext.Usuario.Remove(userDb);
            _dataBaseContext.SaveChanges();

            return true;
        }
    }
}
