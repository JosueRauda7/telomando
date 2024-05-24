using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public SucursalesController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaSucursales()
        {
            List<Sucursale> lista = _DBContext.Sucursales.ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult Sucursal_Detalle(int idSucursal)
        {
            Sucursale oSucursal = new Sucursale();


            if (idSucursal != 0)
            {
                oSucursal = _DBContext.Sucursales.Find(idSucursal);
            }


            return View(oSucursal);
        }

        [HttpGet]
        public IActionResult Eliminar(int idSucursal)
        {
            Sucursale oSucursal = _DBContext.Sucursales.Where(s => s.Idsucursal == idSucursal).FirstOrDefault();


            return View(oSucursal);
        }

        [HttpPost]
        public IActionResult Eliminar(Sucursale oSucursal)
        {
            _DBContext.Sucursales.Remove(oSucursal);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaSucursales", "Sucursales");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sucursal_Detalle(Sucursale oSucursal)
        {


            if (ModelState.IsValid)
            {
                if (oSucursal.Idsucursal == 0)
                {
                    _DBContext.Sucursales.Add(oSucursal);

                }
                else
                {
                    _DBContext.Sucursales.Update(oSucursal);
                }
                _DBContext.SaveChanges();
                TempData["AlertMessage"] = "Registro creado exitosamente";
                TempData["AlertType"] = "success";
                return RedirectToAction("ListaSucursales", "Sucursales");
            }

            TempData["AlertMessage"] = "Error al crear el registro";
            TempData["AlertType"] = "error";
            return View(oSucursal);



        }
    }
}
