using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Text;
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
            ViewBag.error = "";
            if(usuarioRegistro == null)
            {
                ViewBag.error += "Datos faltantes.";
                return View("Index");
            }

            if (!usuarioRegistro.password.Equals(usuarioRegistro.passwordConfirmacion))
            {
                ViewBag.error += ("Contraseñas no coinciden.");
                return View("Index");
            }

            if(usuarioRegistro.emailPrincipal == usuarioRegistro.emailSecundario)
            {
                ViewBag.error += "Correo principal y secundario no puede ser el mismo.";
                return View("Index");
            }

            Email correo1Existe = _DBContext.Emails.Include(email => email.Email1).Where(email => email.Email1 == usuarioRegistro.emailPrincipal).FirstOrDefault();
            if(correo1Existe != null)
            {
                ViewBag.error += "Correo principal ya existe.";
                return View("Index");
            }
            Email correo2Existe = _DBContext.Emails.Include(email => email.Email1).Where(email => email.Email1 == usuarioRegistro.emailSecundario).FirstOrDefault();
            if (correo2Existe != null)
            {
                ViewBag.error += "Correo secundario ya existe.";
                return View("Index");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
