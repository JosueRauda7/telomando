using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Telomando.Models.ViewModels;

using Telomando.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace Telomando.Controllers
{
    public class EntregasController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public EntregasController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaEntregas()
        {
            List<Entrega> lista = _DBContext.Entregas.Include(b => b.oBodega).Include(c => c.oCliente).Include(d => d.oDireccion).Include(t => t.oTarifa).Include(tp => tp.oTipoPago).Include(t => t.oTrasnporte).ToList();


            return View(lista);
        }

        [HttpGet]
        public IActionResult Entrega_Detalle(int idEntrega)
        {
            EntregasVM oEntregaVM = new EntregasVM()
            {
                oListaBodega = _DBContext.Bodegas.Select(bodega => new SelectListItem()
                {
                    Text = bodega.Idbodega.ToString(),
                    Value = bodega.Idbodega.ToString()
                }).ToList(),

                oListaCliente = _DBContext.Clientes.Select(cliente => new SelectListItem()
                {
                    Text = cliente.oUsuario.Nombres,
                    Value = cliente.Idcliente.ToString()
                }).ToList(),

                oListaDireccion = _DBContext.Direcciones.Select(direccion => new SelectListItem()
                {
                    Text = direccion.Direccion1,
                    Value = direccion.Iddireccion.ToString()
                }).ToList(),

                oListaTarifa = _DBContext.Tarifas.Select(tarifa => new SelectListItem()
                {
                    Text = tarifa.Valor.ToString(),
                    Value = tarifa.Idtarifa.ToString()
                }).ToList(),

                oListaTipoPago = _DBContext.TipoPagos.Select(tipoPago => new SelectListItem()
                {
                    Text = tipoPago.Nombre,
                    Value = tipoPago.Idtipopago.ToString()
                }).ToList(),

                oListaTransporte = _DBContext.Transportes.Select(transporte => new SelectListItem()
                {
                    Text = transporte.Placa,
                    Value = transporte.Idtransporte.ToString()
                }).ToList(),

                oEntrega = new Entrega(),
                
            };

            if (idEntrega != 0)
            {
                oEntregaVM.oEntrega = _DBContext.Entregas.Find(idEntrega);
            }


            return View(oEntregaVM);
        }


        [HttpGet]
        public IActionResult Eliminar(int idEntrega)
        {
            Entrega oEntrega = _DBContext.Entregas.Include(c => c.oCliente).Where(e => e.Identrega == idEntrega).FirstOrDefault();


            return View(oEntrega);

        }

        [HttpPost]
        public IActionResult Eliminar(Entrega oEntrega)
        {
            _DBContext.Entregas.Remove(oEntrega);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaEntregas", "Entregas");
        }

        [HttpPost]
        public IActionResult Entrega_Detalle(EntregasVM oEntregaVM)
        {
            if (oEntregaVM.oEntrega.Identrega == 0)
            {
                _DBContext.Entregas.Add(oEntregaVM.oEntrega);

            }
            else
            {
                _DBContext.Entregas.Update(oEntregaVM.oEntrega);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaEntregas", "Entregas");
        }
    }
}
