using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public CategoriasController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaCategorias()
        {
            List<Categoria> lista = _DBContext.Categorias.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult Categoria_Detalle(int idCategoria)
        {
            Categoria oCategoria = new Categoria();


            if (idCategoria != 0)
            {
                oCategoria = _DBContext.Categorias.Find(idCategoria);
            }


            return View(oCategoria);
        }

        [HttpGet]
        public IActionResult Eliminar(int idCategoria)
        {
            Categoria oCategoria = _DBContext.Categorias.Where(c => c.Idcategoria == idCategoria).FirstOrDefault();


            return View(oCategoria);
        }

        [HttpPost]
        public IActionResult Eliminar(Categoria oCategoria)
        {
            _DBContext.Categorias.Remove(oCategoria);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaCategorias", "Categorias");
        }

        [HttpPost]
        public IActionResult Categoria_Detalle(Categoria oCategoria)
        {
            if (oCategoria.Idcategoria == 0)
            {
                _DBContext.Categorias.Add(oCategoria);

            }
            else
            {
                _DBContext.Categorias.Update(oCategoria);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaCategorias", "Categorias");
        }
    }
}
