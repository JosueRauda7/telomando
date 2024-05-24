using Microsoft.AspNetCore.Mvc;
using Telomando.Models;

namespace Telomando.Controllers
{
    public class LoginController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public LoginController(TelomandofinalContext context)
        {
            _DBContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validate(string correo, string password)
        {
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Register(UsuarioRegistro usuarioRegistro)
        {
            if(usuarioRegistro == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
