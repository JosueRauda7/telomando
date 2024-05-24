using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class PaisesController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public PaisesController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaPaises()
        {
            List<Paise> lista = _DBContext.Paises.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult Paises_Detalle(int idPais)
        {
            Paise oPais = new Paise();
            oPais.FechaRegistro = DateOnly.FromDateTime(DateTime.Now);


            if (idPais != 0)
            {
                oPais = _DBContext.Paises.Find(idPais);
            }


            return View(oPais);
        }

        [HttpGet]
        public IActionResult Eliminar(int idPais)
        {
            Paise oPais = _DBContext.Paises.Where(p => p.Idpaises == idPais).FirstOrDefault();


            return View(oPais);
        }

        [HttpPost]
        public IActionResult Eliminar(Paise oPais)
        {
            try {
                _DBContext.Paises.Remove(oPais);
                _DBContext.SaveChanges();

                return RedirectToAction("ListaPaises", "Paises");
            }
            catch (Exception ex) {
                // Obtener el mensaje de la excepción interna si existe
                string errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                ModelState.AddModelError("", "Ocurrió un error al crear el país. Por favor, inténtelo de nuevo.");
                TempData["AlertMessage"] = errorMessage;
                TempData["AlertType"] = "error";
                return View(oPais);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Paises_Detalle(Paise oPais)
        {


            if (ModelState.IsValid)
            {
                if (oPais.Idpaises == 0)
                {
                    _DBContext.Paises.Add(oPais);

                }
                else
                {
                    _DBContext.Paises.Update(oPais);
                }
                _DBContext.SaveChanges();
                TempData["AlertMessage"] = "Registro creado exitosamente";
                TempData["AlertType"] = "success"; 
                return RedirectToAction("ListaPaises", "Paises");
            }

            TempData["AlertMessage"] = "Error al crear el registro";
            TempData["AlertType"] = "error";
            return View(oPais);


            
        }
    }
}
