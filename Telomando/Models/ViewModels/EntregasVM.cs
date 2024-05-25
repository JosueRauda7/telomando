using Microsoft.AspNetCore.Mvc.Rendering;

namespace Telomando.Models.ViewModels
{
    public class EntregasVM
    {
        public Entrega oEntrega { get; set; }

        public List<SelectListItem> oListaBodega { get; set; }

        public List<SelectListItem> oListaCliente { get; set; }

        public List<SelectListItem> oListaDireccion { get; set; }

        public List<SelectListItem> oListaTarifa { get; set; }

        public List<SelectListItem> oListaTipoPago { get; set; }

        public List<SelectListItem> oListaTransporte { get; set; }


    }
}
