using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


using Telomando.Models.ViewModels;
using Telomando.Models;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public DepartamentosController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaDepartamentos()
        {
            List<Departamento> lista = _DBContext.Departamentos.Include(p => p.oPaises).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult Departamento_Detalle(int idDepartamento)
        {
            DepartamentosVM oDepartamentoVM = new DepartamentosVM()
            {
                oDepartamento = new Departamento(),
                oListaPaise = _DBContext.Paises.Select(pais => new SelectListItem()
                {
                    Text = pais.Nombre,
                    Value = pais.Idpaises.ToString()
                }).ToList(),
            };

            if (idDepartamento != 0)
            {
                oDepartamentoVM.oDepartamento = _DBContext.Departamentos.Find(idDepartamento);
            }


            return View(oDepartamentoVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idDepartamento)
        {
            Departamento oDepartamento = _DBContext.Departamentos.Include(p => p.oPaises).Where(d => d.Iddepartamento == idDepartamento).FirstOrDefault();


            return View(oDepartamento);

        }

        [HttpPost]
        public IActionResult Eliminar(Departamento oDepartamento)
        {
            _DBContext.Departamentos.Remove(oDepartamento);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaDepartamentos", "Departamentos");
        }

        [HttpPost]
        public IActionResult Departamento_Detalle(DepartamentosVM oDepartamentoVM)
        {
            if (oDepartamentoVM.oDepartamento.Iddepartamento == 0)
            {
                _DBContext.Departamentos.Add(oDepartamentoVM.oDepartamento);

            }
            else
            {
                _DBContext.Departamentos.Update(oDepartamentoVM.oDepartamento);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaDepartamentos", "Departamentos");
        }
    }
}
