using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


using Telomando.Models.ViewModels;
using Telomando.Models;
using System.Diagnostics;
namespace Telomando.Controllers
{
    public class MarcaTransporteController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public MarcaTransporteController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaMarcaTransporte()
        {
            List<MarcaTransporte> lista = _DBContext.MarcaTransportes.Include(d => d.IdmodelotransporteNavigation).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult MarcaTransporte_Detalle(int idMarcaTransporte)
        {
            MarcaTransporteVM oMarcaTransporteVM = new MarcaTransporteVM()
            {
                oMarcaTransporte = new MarcaTransporte(),
                oListaModeloTransporte = _DBContext.ModeloTransportes.Select(modeloTransporte => new SelectListItem()
                {
                    Text = modeloTransporte.Nombre,
                    Value = modeloTransporte.Idmodelotransporte.ToString()
                }).ToList(),
            };

            if (idMarcaTransporte != 0)
            {
                oMarcaTransporteVM.oMarcaTransporte = _DBContext.MarcaTransportes.Find(idMarcaTransporte);
            }


            return View(oMarcaTransporteVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idMarcaTransporte)
        {
            MarcaTransporte oMarcaTransporte = _DBContext.MarcaTransportes.Include(d => d.IdmodelotransporteNavigation).Where(m => m.Idmarcatransporte == idMarcaTransporte).FirstOrDefault();


            return View(oMarcaTransporte);

        }

        [HttpPost]
        public IActionResult Eliminar(MarcaTransporte oMarcaTransporte)
        {
            _DBContext.MarcaTransportes.Remove(oMarcaTransporte);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaMarcaTransporte", "MarcaTransporte");
        }

        [HttpPost]
        public IActionResult MarcaTransporte_Detalle(MarcaTransporteVM oMarcaTransporteVM)
        {
            if (oMarcaTransporteVM.oMarcaTransporte.Idmarcatransporte == 0)
            {
                _DBContext.MarcaTransportes.Add(oMarcaTransporteVM.oMarcaTransporte);

            }
            else
            {
                _DBContext.MarcaTransportes.Update(oMarcaTransporteVM.oMarcaTransporte);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaMarcaTransporte", "MarcaTransporte");
        }
    }
}
