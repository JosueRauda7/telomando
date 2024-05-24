using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Telomando.Models.ViewModels;

using Telomando.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Telomando.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public DireccionesController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaDirecciones()
        {
            List<Direccione> lista = _DBContext.Direcciones.Include(c => c.oCiudad).Include(s => s.oSucursal).Include(u => u.oUsuario).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult Direccion_Detalle(int idDireccion)
        {
            DireccionesVM oDireccionVM = new DireccionesVM()
            { 
                oListaUsuarios = _DBContext.Usuarios.Select(usuario => new SelectListItem()
                {
                    Text = usuario.Nombres,
                    Value = usuario.Idusuario.ToString()
                }).ToList(), 
                
                oListaSucursales = _DBContext.Sucursales.Select(sucursal => new SelectListItem()
                 {
                     Text = sucursal.Nombre,
                     Value = sucursal.Idsucursal.ToString()
                 }).ToList(),

                oDirecciones = new Direccione(),
                oListaCiudades = _DBContext.Ciudades.Select(ciudad => new SelectListItem()
                {
                    Text = ciudad.Nombre,
                    Value = ciudad.Idciudad.ToString()
                }).ToList(),
            };

            if (idDireccion != 0)
            {
                oDireccionVM.oDirecciones = _DBContext.Direcciones.Find(idDireccion);
            }


            return View(oDireccionVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idDireccion)
        {
            Direccione oDireccion = _DBContext.Direcciones.Include(c => c.oCiudad).Where(cd => cd.Iddireccion == idDireccion).FirstOrDefault();


            return View(oDireccion);

        }

        [HttpPost]
        public IActionResult Eliminar(Direccione oDireccion)
        {
            _DBContext.Direcciones.Remove(oDireccion);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaDirecciones", "Direcciones");
        }

        [HttpPost]
        public IActionResult Direccion_Detalle(DireccionesVM oDireccionVM)
        {
            if (oDireccionVM.oDirecciones.Iddireccion == 0)
            {
                _DBContext.Direcciones.Add(oDireccionVM.oDirecciones);

            }
            else
            {
                _DBContext.Direcciones.Update(oDireccionVM.oDirecciones);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaDirecciones", "Direcciones");
        }
    }
}
