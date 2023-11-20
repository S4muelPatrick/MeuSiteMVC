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
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel user = _usuarioRepositorio.ListarPorId(id);
            return View(user);
        }

        public IActionResult Remove(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Remove(id);
                if (apagado == true)
                {
                    TempData["SuccessMessage"] = "User has been deleted successfuly!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Ops! We Contact couldn't be deleted. Try Again!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ops! We User couldn't be deleted. More details: {ex.Message}";
                return RedirectToAction("Index");
            }
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
                TempData["ErrorMessage"] = $"Ops, we couldn't register the user, please, try again";
                return RedirectToAction("Index");
            }
        }    

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel userSemSenhaModel)
        {
            try
            {
                UsuarioModel user = null;
                if (ModelState.IsValid)
                {
                    user = new UsuarioModel()
                    {
                        Id = userSemSenhaModel.Id,
                        Nome = userSemSenhaModel.Nome,
                        Login = userSemSenhaModel.Login,
                        Email = userSemSenhaModel.Email,
                        Perfil = userSemSenhaModel.Perfil
                    };


                    user = _usuarioRepositorio.Update(user);
                    TempData["SuccessMessage"] = "Contact has been updated successfully!";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = $"Ops, we coulden't update the contact, please, try again, error details:{ex.Message}";
                return View("Editar", userSemSenhaModel);
            }
        }
    }
}
