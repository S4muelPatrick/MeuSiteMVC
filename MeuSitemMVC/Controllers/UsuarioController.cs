using MeuSitemMVC.Migrations;
using MeuSitemMVC.Models;
using MeuSitemMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuSitemMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        //Mostra a lista de usuários no index
        public IActionResult Index()
        {
            List<UsuarioModel> user = _usuarioRepositorio.BuscarTodos();
            return View(user);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Add(user);
                    TempData["SuccessMessage"] = "User has been registered successfuly!";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ops, we coulden't register the user, please, try again, error details:{ex.Message}";
                return RedirectToAction("Index");
            }
        }

        //Joga para a página de criação
        public IActionResult Criar()
        {
            return View();
        }
        //Edit
        public IActionResult Editar(int id)
        {
            //Para retornar na view edit os dados do Id  selecionado
            UsuarioModel user = _usuarioRepositorio.ListarPorId(id);
            return View(user);
        }
    }
}
