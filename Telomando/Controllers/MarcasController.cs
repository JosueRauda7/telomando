using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class MarcasController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public MarcasController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaMarcas()
        {
            List<Marca> lista = _DBContext.Marcas.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult Marca_Detalle(int idMarca)
        {
            Marca oMarca = new Marca();


            if (idMarca != 0)
            {
                oMarca = _DBContext.Marcas.Find(idMarca);
            }


            return View(oMarca);
        }

        [HttpGet]
        public IActionResult Eliminar(int idMarca)
        {
            Marca oMarca = _DBContext.Marcas.Where(m => m.Idmarca == idMarca).FirstOrDefault();


            return View(oMarca);
        }

        [HttpPost]
        public IActionResult Eliminar(Marca oMarca)
        {
            _DBContext.Marcas.Remove(oMarca);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaMarcas", "Marcas");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Marca_Detalle(Marca oMarca)
        {


            if (ModelState.IsValid)
            {
                if (oMarca.Idmarca == 0)
                {
                    _DBContext.Marcas.Add(oMarca);

                }
                else
                {
                    _DBContext.Marcas.Update(oMarca);
                }
                _DBContext.SaveChanges();
                TempData["AlertMessage"] = "Registro creado exitosamente";
                TempData["AlertType"] = "success";
                return RedirectToAction("ListaMarcas", "Marcas");
            }

            TempData["AlertMessage"] = "Error al crear el registro";
            TempData["AlertType"] = "error";
            return View(oMarca);



        }
    }
}
