using Microsoft.AspNetCore.Mvc;
using Telomando.Extensions;
using Telomando.Models;

namespace Telomando.Controllers
{
    public class UsuarioInfo : Controller
    {
        private readonly TelomandofinalContext _DBContext;
        public UsuarioInfo(TelomandofinalContext context)
        {
            _DBContext = context;
        }
        public IActionResult Index()
        {
            UsuarioLoginData usuarioLoginData = HttpContext.Session.GetObject<UsuarioLoginData>("usuario");
            Usuario usuario = _DBContext.Usuarios.Find(usuarioLoginData.idUsuario);
            Email usuarioEmail = _DBContext.Emails.Find(usuarioLoginData.idUsuario);
            Contacto usuarioContacto = _DBContext.Contactos.Find(usuarioLoginData.idUsuario);
            Direccione usuarioDirecciones = _DBContext.Direcciones.Find(usuarioLoginData.idUsuario);

            ViewBag.usuario = usuario;
            ViewBag.usuarioEmail = usuarioEmail;
            ViewBag.usuarioContacto = usuarioContacto;
            ViewBag.usuarioDirecciones = usuarioDirecciones;
            return View();
        }
    }
}
