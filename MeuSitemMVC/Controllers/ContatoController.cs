using MeuSitemMVC.Models;
using MeuSitemMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace MeuSitemMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }

        //Mostra a lista de contatos no index
        public IActionResult Index()
        {
            List<ContatoModel> contato = _contatoRepositorio.BuscarTodos();
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Add(contato);
                    TempData["SuccessMessage"] = "Contact has been registered successfuly!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception ex)
            {
                
                TempData["ErrorMessage"] = $"Ops, we coulden't register the contact, please, try again, error details:{ex.Message }";
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
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Remove(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Remove(id);
                if (apagado == true)
                {
                    TempData["SuccessMessage"] = "Contact has been deleted successfuly!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Ops! We Contact couldn't be deleted. Try Again!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Ops! We Contact couldn't be deleted. More details: {ex.Message}";
                return RedirectToAction("Index");
            }      
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Update(contato);
                    TempData["SuccessMessage"] = "Contact has been updated successfully!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = $"Ops, we coulden't update the contact, please, try again, error details:{ex.Message}";
                return View("Editar", contato);
            } 
        }
    }
}
