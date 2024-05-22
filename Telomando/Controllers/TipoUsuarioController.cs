using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;


using System.Diagnostics;

namespace Telomando.Controllers
{
    public class TipoUsuarioController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public TipoUsuarioController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaTiposUsuarios()
        {
            List<TipoUsuario> lista = _DBContext.TipoUsuarios.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult TiposUsuarios_Detalle(int idTipoUsuario)
        {
            TipoUsuario oTipoUsuario = new TipoUsuario();


            if (idTipoUsuario != 0)
            {
                oTipoUsuario = _DBContext.TipoUsuarios.Find(idTipoUsuario);
            }


            return View(oTipoUsuario);
        }

        [HttpGet]
        public IActionResult Eliminar(int idTipoUsuario)
        {
            TipoUsuario oTipoUsuario = _DBContext.TipoUsuarios.Where(t => t.Idtipousuario == idTipoUsuario).FirstOrDefault();


            return View(oTipoUsuario);
        }

        [HttpPost]
        public IActionResult Eliminar(TipoUsuario oTipoUsuario)
        {
            _DBContext.TipoUsuarios.Remove(oTipoUsuario);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaTiposUsuarios", "TipoUsuario");
        }

        [HttpPost]
        public IActionResult TiposUsuarios_Detalle(TipoUsuario oTipoUsuario)
        {
            if (oTipoUsuario.Idtipousuario == 0)
            {
                _DBContext.TipoUsuarios.Add(oTipoUsuario);

            }
            else
            {
                _DBContext.TipoUsuarios.Update(oTipoUsuario);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaTiposUsuarios", "TipoUsuario");
        }
    }
}
