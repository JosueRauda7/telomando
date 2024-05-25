using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using Telomando.Extensions;
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

        public IActionResult Logout()
        {
            UsuarioLoginData usuarioLoginData = HttpContext.Session.GetObject<UsuarioLoginData>("usuario");
            usuarioLoginData.logueado = false;
            HttpContext.Session.SetObject("usuario", usuarioLoginData);
            return View("Index");
        }

        [HttpPost]
        public ActionResult Validate(string correo, string password)
        {
            Email email = _DBContext.Emails.Include(email => email.Email1).Where(email => email.Email1.Equals(correo)).FirstOrDefault();
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);
            SHA512 sha512 = SHA512.Create();
            byte[] passwordToBytes = sha512.ComputeHash(bytePassword);

            UsuarioPassword usuarioPassword = _DBContext.UsuarioPasswords.Include(password => password.Pwd).Where(password => password.Pwd.Equals(passwordToBytes)).FirstOrDefault();

            if(email != null && usuarioPassword != null) {
                if(email.Idusuario == usuarioPassword.Idusuario)
                {
                    Usuario usuario = _DBContext.Usuarios.Find(email.Idusuario);
                    usuario.Logueado = "SI";

                    UsuarioLoginData usuarioLoginData = new UsuarioLoginData();
                    usuarioLoginData.idUsuario = email.Idusuario;
                    usuarioLoginData.username = usuario.Nombres + " " + usuario.Apellidos;
                    usuarioLoginData.correo = correo;
                    usuarioLoginData.logueado = true;
                    usuarioLoginData.idTipoUsuario = usuario.Idtipousuario;

                    HttpContext.Session.SetObject("usuario", usuarioLoginData);

                    _DBContext.SaveChanges();
                    
                    return RedirectToAction("Index","Home");
                }
            }

            // cerrar sesión
            UsuarioLoginData usuarioSesion = HttpContext.Session.GetObject<UsuarioLoginData>("usuario");
            if(usuarioSesion != null)
            {
                usuarioSesion.logueado = false;
                HttpContext.Session.SetObject("usuario", usuarioSesion);
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

            Cliente cliente = new Cliente();
            cliente.Idusuario = usuario.Idusuario;
            cliente.Idtipocliente = 1;
            cliente.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);
            cliente.Activo = true;
            cliente.Eliminado = false;
            _DBContext.Clientes.Add(cliente);
            _DBContext.SaveChanges();

            UsuarioLoginData usuarioLoginData = new UsuarioLoginData();
            usuarioLoginData.idUsuario = usuario.Idusuario;
            usuarioLoginData.username = usuario.Nombres + " " + usuario.Apellidos;
            usuarioLoginData.correo = email.Email1;
            usuarioLoginData.logueado = true;
            usuarioLoginData.idTipoUsuario = 2;

            HttpContext.Session.SetObject("usuario", usuarioLoginData);

            return RedirectToAction("Index", "Home");
        }
    }
}
