using MeuSitemMVC.Data;
using MeuSitemMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuSitemMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly DataBaseContext _dataBaseContext;
        public ContatoRepositorio(DataBaseContext bdContext) 
        {
            _dataBaseContext = bdContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _dataBaseContext.Contato.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _dataBaseContext.Contato.ToList();
        }

        public ContatoModel Add(ContatoModel contato)
        {
            //Record in DataBase
            contato.Celular = contato.Celular
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "");
            
            _dataBaseContext.Contato.Add(contato);
            _dataBaseContext.SaveChanges();

            return contato;
        }

        public ContatoModel Update(ContatoModel contato)
        {
           ContatoModel contatoDb = ListarPorId(contato.Id);

            if (contatoDb == null)
            {
                throw new Exception("Houve um erro na atualização do contato");
            }

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            contato.Celular = contato.Celular
                .Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "");
            _dataBaseContext.Update(contatoDb);
            _dataBaseContext.SaveChanges();

            return contatoDb;
        }

        public bool Remove(int id)
        {
            //Delete from DataBase
            ContatoModel contatoDb = ListarPorId(id);
            if (contatoDb == null)
            {
                throw new Exception("Houve um erro ao deletar do contato");
            }
            _dataBaseContext.Contato.Remove(contatoDb);
            _dataBaseContext.SaveChanges();

            return true;
        }
    }
}
