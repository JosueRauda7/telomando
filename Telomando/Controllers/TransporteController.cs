using Microsoft.AspNetCore.Mvc;
using Telomando.Models;
using Telomando.Models.ViewModels;

namespace Telomando.Controllers
{
    public class TransporteController : Controller
    {
        private readonly TelomandofinalContext _DBContext;

        public TransporteController(TelomandofinalContext context)
        {
            _DBContext = context;
        }

        public IActionResult ListaTransporte()
        {
            List<Transporte> lista = _DBContext.Transportes.ToList();

            foreach (Transporte transporte in lista)
            {
                transporte.MarcaTransporte= _DBContext.MarcaTransportes.Find(transporte.Idmarcatransporte);
                transporte.TipoTransporte = _DBContext.TipoTransportes.Find(transporte.Idtipotransporte);

            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult Transporte_Detalle(int idTransporte)
        {
            Transporte transporte = new Transporte();
            List<MarcaTransporte> marcas = _DBContext.MarcaTransportes.ToList();
            ViewBag.ListaMarcas = marcas;
            List<TipoTransporte> tiposTransporte = _DBContext.TipoTransportes.ToList();
            ViewBag.ListaTipoTransporte = tiposTransporte;
            if (idTransporte != 0) {
                transporte = _DBContext.Transportes.Find(idTransporte);
            }
            return View(transporte);
        }


        [HttpPost]
        public ActionResult Transporte_Detalle(Transporte transporte)
        {
            if (transporte.Idtransporte == 0)
            {
                _DBContext.Transportes.Add(transporte);

            }
            else
            {
                _DBContext.Transportes.Update(transporte);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("ListaTransporte", "Transporte");
        }


        [HttpGet]
        public ActionResult Eliminar(int idTransporte)
        {
            List<MarcaTransporte> marcas = _DBContext.MarcaTransportes.ToList();
            ViewBag.ListaMarcas = marcas;
            List<TipoTransporte> tiposTransporte = _DBContext.TipoTransportes.ToList();
            ViewBag.ListaTipoTransporte = tiposTransporte;
            Transporte transporte =  _DBContext.Transportes.Find(idTransporte);



            return View(transporte);

        }

        [HttpPost]
        public IActionResult Eliminar(Transporte transporte)
        {
            _DBContext.Transportes.Remove(transporte);
            _DBContext.SaveChanges();

            return RedirectToAction("ListaTransporte", "Transporte");
        }



    }
}
