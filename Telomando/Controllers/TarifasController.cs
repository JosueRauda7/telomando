using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


using Telomando.Models.ViewModels;
using Telomando.Models;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class TarifasController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public TarifasController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaTarifas()
        {
            List<Tarifa> lista = _DBContext.Tarifas.Include(t=>t.oMomedas).ToList();


            return View(lista);
        }


        [HttpGet]
        public IActionResult Tarifas_Detalle(int idTarifa)
        {
            TarifaVM oTarifaVM = new TarifaVM()
            {
                oTarifas= new Tarifa(),
                oListaMonedas = _DBContext.Monedas.Select(moneda => new SelectListItem()
                {
                    Text = moneda.Nombre,
                    Value = moneda.Idmoneda.ToString()
                }).ToList(),
            };

            if (idTarifa != 0)
            {
                oTarifaVM.oTarifas = _DBContext.Tarifas.Find(idTarifa);
            }


            return View(oTarifaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Tarifas_Detalle(TarifaVM oTarifaVM)
        {
           if (oTarifaVM.oTarifas.Idtarifa == 0)
                {
                    _DBContext.Tarifas.Add(oTarifaVM.oTarifas);

                }
                else
                {
                    _DBContext.Tarifas.Update(oTarifaVM.oTarifas);
                 
                }

                _DBContext.SaveChanges(); 
                return RedirectToAction("ListaTarifas", "Tarifas");
            }
           

        

        public IActionResult Eliminar(int idTarifa)
        {
            Tarifa oTarifa = _DBContext.Tarifas.Include(m => m.oMomedas).Where(t => t.Idtarifa == idTarifa).FirstOrDefault();


            return View(oTarifa);

        }

        [HttpPost]
         public IActionResult Eliminar(Tarifa oTarifa)
         {
             _DBContext.Tarifas.Remove(oTarifa);
                _DBContext.SaveChanges();

                return RedirectToAction("ListaTarifas", "Tarifas");
         }



    }
}
