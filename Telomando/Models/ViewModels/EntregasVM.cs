using Microsoft.AspNetCore.Mvc.Rendering;

namespace Telomando.Models.ViewModels
{
    public class EntregasVM
    {
        public Entrega oEntrega { get; set; }

        public List<SelectListItem> oListaBodega { get; set; }

        public List<SelectListItem> oListaDireccione { get; set; }

        public List<SelectListItem> oListaCliente { get; set; }
    }
}
