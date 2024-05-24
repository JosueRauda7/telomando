using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class TipoPagosController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public TipoPagosController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaTiposPagos()
        {
            List<TipoPago> lista = _DBContext.TipoPagos.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult TipoPago_Detalle(int idTipoPago)
        {
            TipoPago oTipoPago = new TipoPago();


            if (idTipoPago != 0)
            {
                oTipoPago = _DBContext.TipoPagos.Find(idTipoPago);
            }


            return View(oTipoPago);
        }

        [HttpGet]
        public IActionResult Eliminar(int idTipoPago)
        {
            TipoPago oTipoPago = _DBContext.TipoPagos.Where(tp => tp.Idtipopago == idTipoPago).FirstOrDefault();


            return View(oTipoPago);
        }

        [HttpPost]
        public IActionResult Eliminar(TipoPago oTipoPago)
        {
            _DBContext.TipoPagos.Remove(oTipoPago);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaTiposPagos", "TipoPagos");
        }

        [HttpPost]
        public IActionResult TipoPago_Detalle(TipoPago oTipoPago)
        {
            if (oTipoPago.Idtipopago == 0)
            {
                _DBContext.TipoPagos.Add(oTipoPago);

            }
            else
            {
                _DBContext.TipoPagos.Update(oTipoPago);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaTiposPagos", "TipoPagos");
        }
    }
}
