using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace Telomando.Controllers
{
    public class TiposTransportesController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public TiposTransportesController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaTiposTransportes()
        {
            List<TipoTransporte> lista = _DBContext.TipoTransportes.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult TipoTransporte_Detalle(int idTipoTransporte)
        {
            TipoTransporte oTipoTransporte = new TipoTransporte();


            if (idTipoTransporte != 0)
            {
                oTipoTransporte = _DBContext.TipoTransportes.Find(idTipoTransporte);
            }


            return View(oTipoTransporte);
        }

        [HttpGet]
        public IActionResult Eliminar(int idTipoTransporte)
        {
            TipoTransporte oTipoTransporte = _DBContext.TipoTransportes.Where(tt => tt.Idtipotransporte == idTipoTransporte).FirstOrDefault();


            return View(oTipoTransporte);
        }

        [HttpPost]
        public IActionResult Eliminar(TipoTransporte oTipoTransporte)
        {
            _DBContext.TipoTransportes.Remove(oTipoTransporte);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaTiposTransportes", "TiposTransportes");
        }

        [HttpPost]
        public IActionResult TipoTransporte_Detalle(TipoTransporte oTipoTransporte)
        {
            if (oTipoTransporte.Idtipotransporte == 0)
            {
                _DBContext.TipoTransportes.Add(oTipoTransporte);

            }
            else
            {
                _DBContext.TipoTransportes.Update(oTipoTransporte);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaTiposTransportes", "TiposTransportes");
        }
    }
}
