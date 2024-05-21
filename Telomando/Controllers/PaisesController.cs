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
            _DBContext.Paises.Remove(oPais);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaPaises", "Paises");
        }

        [HttpPost]
        public IActionResult Paises_Detalle(Paise oPais)
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
            return RedirectToAction("ListaPaises", "Paises");
        }
    }
}
