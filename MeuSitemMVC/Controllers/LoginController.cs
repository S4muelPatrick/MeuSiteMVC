using Microsoft.AspNetCore.Mvc;

namespace MeuSitemMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
