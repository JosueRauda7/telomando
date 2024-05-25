using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using Telomando.Models;
using System.;

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
            Email email = _DBContext.Emails.Include(email => email.Email1).Where(email => email.Email1 == correo).FirstOrDefault();
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);
            SHA512 sha512 = SHA512.Create();
            byte[] passwordToBytes = sha512.ComputeHash(bytePassword);

            UsuarioPassword usuarioPassword = _DBContext.UsuarioPasswords.Include(password => password.Pwd).Where(password => password.Pwd.Equals(passwordToBytes)).FirstOrDefault();

            if(email != null && usuarioPassword != null) {
                if(email.Idusuario == usuarioPassword.Idusuario)
                {
                    Usuario usuario = _DBContext.Usuarios.Find(email.Idusuario);
                    usuario.Logueado = "SI";

                    Session["usuarioId"] = usuario.Idusuario;
                    Session["correo"] = email.Email1;
                    Session["nombreCompleto"] = usuario.Nombres+" "+usuario.Apellidos;
                    Session["logueado"] = usuario.Logueado;
                    _DBContext.SaveChanges();
                    
                    return RedirectToAction("Index","Home");
                }
            }

            ViewBag.error += "Credenciales incorrectas.";
            return View("Index");
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

            Usuario usuario = new Usuario();
            usuario.Nombres = usuarioRegistro.nombres;
            usuario.Apellidos = usuarioRegistro.apellidos;
            usuario.Idtipousuario = 2;
            usuario.Logueado = "SI";
            usuario.Bloqueado = "NO";
            usuario.IntentosLogin = 0;
            usuario.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            usuario.Activo = true;
            usuario.Eliminado = false;

            _DBContext.Usuarios.Add(usuario);
            _DBContext.SaveChanges();

            UsuarioPassword usuarioPassword = new UsuarioPassword();
            usuarioPassword.Idusuario = usuario.Idusuario;
            byte[] bytePassword = Encoding.UTF8.GetBytes(usuarioRegistro.password);
            SHA512 sha512 = SHA512.Create();
            byte[] passwordToBytes = sha512.ComputeHash(bytePassword);
            usuarioPassword.Pwd = passwordToBytes;
            usuarioPassword.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            usuarioPassword.FechaVencimiento = DateOnly.FromDateTime(DateTime.Now).AddMonths(3);
            usuarioPassword.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            usuarioPassword.Activo = true;
            usuarioPassword.Eliminado = false;
            _DBContext.UsuarioPasswords.Add(usuarioPassword);
            _DBContext.SaveChanges();

            Contacto contacto = new Contacto();
            contacto.Idusuario = usuario.Idusuario;
            contacto.Contacto1 = usuarioRegistro.telefono1;
            contacto.Contacto2 = usuarioRegistro.telefono2;
            contacto.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            contacto.Activo = true;
            contacto.Eliminado = false;
            _DBContext.Contactos.Add(contacto);
            _DBContext.SaveChanges();

            Email email = new Email();
            email.Idusuario = usuario.Idusuario;
            email.Email1 = usuarioRegistro.emailPrincipal;
            email.Email2 = usuarioRegistro.emailSecundario;
            email.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            email.Activo = true;
            email.Eliminado = false;
            _DBContext.Emails.Add(email);
            _DBContext.SaveChanges();

            HttpContext.Session.SetInt32("idusuario",usuario.Idusuario);
            HttpContext.Session.SetString("correo", email.Email1);
            HttpContext.Session.SetString("nombre", usuario.Nombres);
            HttpContext.Session.SetString("apellido", usuario.Apellidos);
            HttpContext.Session.SetString("logueado", usuario.Logueado);

            return RedirectToAction("Index", "Home");
        }
    }
}
