using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Telomando.Models.ViewModels;

using Telomando.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class BodegasProductosController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public BodegasProductosController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaBodegasProductos()
        {
            List<BodegaProducto> lista = _DBContext.BodegaProductos.Include(b=> b.oBodega).Include(p => p.oProducto).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult BodegaProducto_Detalle(int idBodegaProducto)
        {
            BodegasProductosVM oBodegaProductoVM = new BodegasProductosVM()
            {
                oBodegaProducto = new BodegaProducto(),
                oListaBodegas = _DBContext.Bodegas.Select(bodega => new SelectListItem()
                {
                    Text = bodega.Idbodega.ToString(),
                    Value = bodega.Idbodega.ToString()
                }).ToList(),

                oListaProductos = _DBContext.Productos.Select(producto => new SelectListItem()
                {
                    Text = producto.Nombre,
                    Value = producto.Idproducto.ToString()
                }).ToList(),

            };

            if (idBodegaProducto != 0)
            {
                oBodegaProductoVM.oBodegaProducto = _DBContext.BodegaProductos.Find(idBodegaProducto);
            }


            return View(oBodegaProductoVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idBodegaProducto)
        {
            BodegaProducto oBodegaProducto = _DBContext.BodegaProductos.Include(p => p.oProducto).Where(bp => bp.Idbodegaproducto == idBodegaProducto).FirstOrDefault();


            return View(oBodegaProducto);

        }

        [HttpPost]
        public IActionResult Eliminar(BodegaProducto oBodegaProducto)
        {
            _DBContext.BodegaProductos.Remove(oBodegaProducto);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaBodegasProductos", "BodegasProductos");
        }

        [HttpPost]
        public IActionResult BodegaProducto_Detalle(BodegasProductosVM oBodegaProductoVM)
        {
            if (oBodegaProductoVM.oBodegaProducto.Idbodegaproducto == 0)
            {
                _DBContext.BodegaProductos.Add(oBodegaProductoVM.oBodegaProducto);

            }
            else
            {
                _DBContext.BodegaProductos.Update(oBodegaProductoVM.oBodegaProducto);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaBodegasProductos", "BodegasProductos");
        }
    }
}
