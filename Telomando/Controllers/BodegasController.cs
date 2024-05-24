using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Telomando.Models.ViewModels;

using Telomando.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class BodegasController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public BodegasController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaBodegas()
        {
            List<Bodega> lista = _DBContext.Bodegas.Include(tc => tc.oTipoBodega).Include(s => s.oSucursal).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult Bodega_Detalle(int idBodega)
        {
            BodegaVM oBodegaVM = new BodegaVM()
            {
                oBodega = new Bodega(),
                oListaTipoBodega = _DBContext.TipoBodegas.Select(tipoBodega => new SelectListItem()
                {
                    Text = tipoBodega.Nombre,
                    Value = tipoBodega.Idtipobodega.ToString()
                }).ToList(),

                oListaSucursal = _DBContext.Sucursales.Select(sucursales => new SelectListItem()
                {
                    Text = sucursales.Nombre,
                    Value = sucursales.Idsucursal.ToString()
                }).ToList(),

            };

            if (idBodega != 0)
            {
                oBodegaVM.oBodega = _DBContext.Bodegas.Find(idBodega);
            }


            return View(oBodegaVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idBodega)
        {
            Bodega oBodega = _DBContext.Bodegas.Include(tb => tb.oTipoBodega).Where(b => b.Idtipobodega == idBodega).FirstOrDefault();


            return View(oBodega);

        }

        [HttpPost]
        public IActionResult Eliminar(Bodega oBodega)
        {
            _DBContext.Bodegas.Remove(oBodega);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaBodegas", "Bodegas");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Bodega_Detalle(BodegaVM oBodegaVM)
        {
            if (ModelState.IsValid)
            {
                if (oBodegaVM.oBodega.Idbodega == 0)
                {
                    _DBContext.Bodegas.Add(oBodegaVM.oBodega);

                }
                else
                {
                    _DBContext.Bodegas.Update(oBodegaVM.oBodega);
                }
                _DBContext.SaveChanges();
                return RedirectToAction("ListaBodegas", "Bodegas");
            }

            TempData["AlertMessage"] = "Error al crear el registro";
            TempData["AlertType"] = "error";
            return RedirectToAction("Bodega_Detalle", "Bodegas", new { idbodega = 0 });

        }
    }
}
