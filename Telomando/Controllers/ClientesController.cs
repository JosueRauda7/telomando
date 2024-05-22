using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Telomando.Models.ViewModels;

using Telomando.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Telomando.Controllers
{
    public class ClientesController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public ClientesController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaClientes()
        {
            List<Cliente> lista = _DBContext.Clientes.Include(tc => tc.oTipoCliente).Include(u => u.oUsuario).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult Cliente_Detalle(int idCliente)
        {
            ClienteVM oClienteVM = new ClienteVM()
            {
                oCliente = new Cliente(),
                oListaTipoCliente = _DBContext.TipoClientes.Select(tipocliente => new SelectListItem()
                {
                    Text = tipocliente.Nombre,
                    Value = tipocliente.Idtipocliente.ToString()
                }).ToList(),

                oListaUsuario = _DBContext.Usuarios.Select(usuario => new SelectListItem()
                {
                    Text = usuario.Nombres,
                    Value = usuario.Idusuario.ToString()
                }).ToList(),

            };

            if (idCliente != 0)
            {
                oClienteVM.oCliente = _DBContext.Clientes.Find(idCliente);
            }


            return View(oClienteVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idCliente)
        {
            Cliente oCliente = _DBContext.Clientes.Include(tc => tc.oTipoCliente).Where(c => c.Idcliente == idCliente).FirstOrDefault();


            return View(oCliente);

        }

        [HttpPost]
        public IActionResult Eliminar(Cliente oCliente)
        {
            _DBContext.Clientes.Remove(oCliente);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaClientes", "Clientes");
        }

        [HttpPost]
        public IActionResult Cliente_Detalle(ClienteVM oClienteVM)
        {
            if (oClienteVM.oCliente.Idcliente == 0)
            {
                _DBContext.Clientes.Add(oClienteVM.oCliente);

            }
            else
            {
                _DBContext.Clientes.Update(oClienteVM.oCliente);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaClientes", "Clientes");
        }
    }
}
