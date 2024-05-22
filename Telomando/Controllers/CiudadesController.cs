using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


using Telomando.Models.ViewModels;
using Telomando.Models;
using System.Diagnostics;
namespace Telomando.Controllers
{
    public class CiudadesController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public CiudadesController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaCiudades()
        {
            List<Ciudade> lista = _DBContext.Ciudades.Include(m => m.oMunicipios).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult Ciudad_Detalle(int idCiudad)
        {
            CiudadesVM oCiudadVM = new CiudadesVM()
            {
                oCiudad = new Ciudade(),
                oListaMunicipios = _DBContext.Municipios.Select(municipio => new SelectListItem()
                {
                    Text = municipio.Nombre,
                    Value = municipio.Idmunicipio.ToString()
                }).ToList(),
            };

            if (idCiudad != 0)
            {
                oCiudadVM.oCiudad = _DBContext.Ciudades.Find(idCiudad);
            }


            return View(oCiudadVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idCiudad)
        {
            Ciudade oCiudad = _DBContext.Ciudades.Include(m => m.oMunicipios).Where(c => c.Idciudad == idCiudad).FirstOrDefault();


            return View(oCiudad);

        }

        [HttpPost]
        public IActionResult Eliminar(Ciudade oCiudad)
        {
            _DBContext.Ciudades.Remove(oCiudad);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaCiudades", "Ciudades");
        }

        [HttpPost]
        public IActionResult Ciudad_Detalle(CiudadesVM oCiudadVM)
        {
            if (oCiudadVM.oCiudad.Idciudad == 0)
            {
                _DBContext.Ciudades.Add(oCiudadVM.oCiudad);

            }
            else
            {
                _DBContext.Ciudades.Update(oCiudadVM.oCiudad);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaCiudades", "Ciudades");
        }
    }
}
