using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


using Telomando.Models.ViewModels;
using Telomando.Models;
using System.Diagnostics;
namespace Telomando.Controllers
{
    public class MunicipiosController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public MunicipiosController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaMunicipios()
        {
            List<Municipio> lista = _DBContext.Municipios.Include(d => d.oDepartamentos).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult Municipio_Detalle(int idMunicipio)
        {
            MunicipiosVM oMunicipioVM = new MunicipiosVM()
            {
                oMunicipio = new Municipio(),
                oListaDepartamento = _DBContext.Departamentos.Select(departamento => new SelectListItem()
                {
                    Text = departamento.Nombre,
                    Value = departamento.Iddepartamento.ToString()
                }).ToList(),
            };

            if (idMunicipio != 0)
            {
                oMunicipioVM.oMunicipio = _DBContext.Municipios.Find(idMunicipio);
            }


            return View(oMunicipioVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idMunicipio)
        {
            Municipio oMunicipio= _DBContext.Municipios.Include(d => d.oDepartamentos).Where(m => m.Idmunicipio == idMunicipio).FirstOrDefault();


            return View(oMunicipio);

        }

        [HttpPost]
        public IActionResult Eliminar(Municipio oMunicipio)
        {
            _DBContext.Municipios.Remove(oMunicipio);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaMunicipios", "Municipios");
        }

        [HttpPost]
        public IActionResult Municipio_Detalle(MunicipiosVM oMunicipioVM)
        {
            if (oMunicipioVM.oMunicipio.Idmunicipio == 0)
            {
                _DBContext.Municipios.Add(oMunicipioVM.oMunicipio);

            }
            else
            {
                _DBContext.Municipios.Update(oMunicipioVM.oMunicipio);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaMunicipios", "Municipios");
        }
    }
}
