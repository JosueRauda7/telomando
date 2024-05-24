using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class TipoBodegasController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public TipoBodegasController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaTiposBodegas()
        {
            List<TipoBodega> lista = _DBContext.TipoBodegas.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult TipoBodega_Detalle(int idTipoBodega)
        {
            TipoBodega oTipoBodega = new TipoBodega();


            if (idTipoBodega != 0)
            {
                oTipoBodega = _DBContext.TipoBodegas.Find(idTipoBodega);
            }


            return View(oTipoBodega);
        }

        [HttpGet]
        public IActionResult Eliminar(int idTipoBodega)
        {
            TipoBodega oTipoBodega = _DBContext.TipoBodegas.Where(tb => tb.Idtipobodega == idTipoBodega).FirstOrDefault();


            return View(oTipoBodega);
        }

        [HttpPost]
        public IActionResult Eliminar(TipoBodega oTipoBodega)
        {
            _DBContext.TipoBodegas.Remove(oTipoBodega);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaTiposBodegas", "TipoBodegas");
        }

        [HttpPost]
        public IActionResult TipoBodega_Detalle(TipoBodega oTipoBodega)
        {
            if (oTipoBodega.Idtipobodega == 0)
            {
                _DBContext.TipoBodegas.Add(oTipoBodega);

            }
            else
            {
                _DBContext.TipoBodegas.Update(oTipoBodega);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaTiposBodegas", "TipoBodegas");
        }
    }
}
