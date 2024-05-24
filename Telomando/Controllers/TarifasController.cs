using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;
using Telomando.Models;
using Telomando.Models.ViewModels;

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
            List<Tarifa> lista = _DBContext.Tarifas.Include(t=>t.IdmonedaNavigation).ToList();


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
            if (ModelState.IsValid)
            {
                if (oTarifaVM.oTarifas.Idtarifa == 0)
                {
                    _DBContext.Tarifas.Add(oTarifaVM.oTarifas);

                }
                else
                {
                    _DBContext.Tarifas.Update(oTarifaVM.oTarifas);
                    _DBContext.SaveChanges();
                    TempData["AlertMessage"] = "Registro creado exitosamente";
                    TempData["AlertType"] = "success";
                    return RedirectToAction("ListaTarifas", "Tarifas");
                }
            }
            TempData["AlertMessage"] = "Error al crear el registro,revise los datos ingresados";
            TempData["AlertType"] = "error";
            return RedirectToAction("Tarifas_Detalle", "Tarifas", new { idTarifa = 0 });

        }



    }
}
