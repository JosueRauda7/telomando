using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


using Telomando.Models.ViewModels;
using Telomando.Models;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class SubCategoriasController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public SubCategoriasController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaSubCategorias()
        {
            List<SubCategoria> lista = _DBContext.SubCategorias.Include(c => c.oCategoria).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult SubCategoria_Detalle(int idSubCategoria)
        {
            SubCategoriasVM oSubCategoriaVM = new SubCategoriasVM()
            {
                oSubCategoria = new SubCategoria(),
                oListaCategoria = _DBContext.Categorias.Select(categoria => new SelectListItem()
                {
                    Text = categoria.Nombre,
                    Value = categoria.Idcategoria.ToString()
                }).ToList(),
            };

            if (idSubCategoria != 0)
            {
                oSubCategoriaVM.oSubCategoria = _DBContext.SubCategorias.Find(idSubCategoria);
            }


            return View(oSubCategoriaVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idSubCategoria)
        {
            SubCategoria oSubCategoria = _DBContext.SubCategorias.Include(c => c.oCategoria).Where(sc => sc.Idsubcategoria == idSubCategoria).FirstOrDefault();


            return View(oSubCategoria);

        }

        [HttpPost]
        public IActionResult Eliminar(SubCategoria oSubCategoria)
        {
            _DBContext.SubCategorias.Remove(oSubCategoria);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaSubCategorias", "SubCategorias");
        }

        [HttpPost]
        public IActionResult SubCategoria_Detalle(SubCategoriasVM oSubCategoriaVM)
        {
            if (oSubCategoriaVM.oSubCategoria.Idsubcategoria == 0)
            {
                _DBContext.SubCategorias.Add(oSubCategoriaVM.oSubCategoria);

            }
            else
            {
                _DBContext.SubCategorias.Update(oSubCategoriaVM.oSubCategoria);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaSubCategorias", "SubCategorias");
        }
    }
}
