using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


using Telomando.Models.ViewModels;
using Telomando.Models;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class ProductosController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public ProductosController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaProductos()
        {
            List<Producto> lista = _DBContext.Productos.Include(m => m.oMarca).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult Producto_Detalle(int idProducto)
        {
            ProductoVM oProductoVM = new ProductoVM()
            {
                oProducto = new Producto(),
                oListaMarca = _DBContext.Marcas.Select(marcas => new SelectListItem()
                {
                    Text = marcas.Nombre,
                    Value = marcas.Idmarca.ToString()
                }).ToList(),
            };

            if (idProducto != 0)
            {
                oProductoVM.oProducto = _DBContext.Productos.Find(idProducto);
            }


            return View(oProductoVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idProducto)
        {
            Producto oProducto = _DBContext.Productos.Include(m => m.oMarca).Where(p => p.Idproducto == idProducto).FirstOrDefault();


            return View(oProducto);

        }

        [HttpPost]
        public IActionResult Eliminar(Producto oProducto)
        {
            _DBContext.Productos.Remove(oProducto);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaProductos", "Productos");
        }

        [HttpPost]
        public IActionResult Producto_Detalle(ProductoVM oProductoVM)
        {
            if (oProductoVM.oProducto.Idproducto == 0)
            {
                _DBContext.Productos.Add(oProductoVM.oProducto);

            }
            else
            {
                _DBContext.Productos.Update(oProductoVM.oProducto);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaProductos", "Productos");
        }
    }
}
