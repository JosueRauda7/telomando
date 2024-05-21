using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;


using System.Diagnostics;



namespace Telomando.Controllers
{
    public class TipoClienteController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public TipoClienteController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaTiposClientes()
        {
            List<TipoCliente> lista = _DBContext.TipoClientes.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult TiposClientes_Detalle(int idTipoCliente)
        {
            TipoCliente oTipoCliente = new TipoCliente();


            if (idTipoCliente != 0)
            {
                oTipoCliente = _DBContext.TipoClientes.Find(idTipoCliente);
            }


            return View(oTipoCliente);
        }

        [HttpGet]
        public IActionResult Eliminar(int idTipoCliente)
        {
            TipoCliente oTipoCliente = _DBContext.TipoClientes.Where(t => t.Idtipocliente == idTipoCliente).FirstOrDefault();


            return View(oTipoCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(TipoCliente oTipoCliente)
        {
            _DBContext.TipoClientes.Remove(oTipoCliente);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaTiposClientes", "TipoCliente");
        }

        [HttpPost]
        public IActionResult TiposClientes_Detalle(TipoCliente oTipoCliente)
        {
            if (oTipoCliente.Idtipocliente == 0)
            {
                _DBContext.TipoClientes.Add(oTipoCliente);

            }
            else
            {
                _DBContext.TipoClientes.Update(oTipoCliente);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaTiposClientes", "TipoCliente");
        }
    }
}
